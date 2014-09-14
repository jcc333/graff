namespace graff.primitives

open System
open System.Collections

type Id = Guid

type PropertySet = Map<string, string>

type Node = 
  struct 
    val label : Id
    val properties : PropertySet
    new(l : Id, p : PropertySet) = {label = l; properties = p}
  end

type Edge = 
  interface
    abstract label : Id
    abstract nodes : Node * Node
  end

type SimpleEdge =
  { label : Id
    nodes : Node * Node
    properties : PropertySet }
  interface Edge with
    member this.label = this.label
    member this.nodes = this.nodes

type DirectedEdge = 
  { label : Id
    source : Node
    target : Node
    properties : PropertySet }
  interface Edge with
    member this.label = this.label
    member this.nodes = (this.source, this.target)

type Entry = 
  interface
    abstract nodes : Node list
    abstract edges : Edge list
  end

type Graph =
  struct
    val entries : Map<Id, Entry>
    new(m : Map<Id, Entry>) = { entries = m }
    member this.add e : Graph = Graph(this.entries.Add(System.Guid.NewGuid(), e))
    member this.remove id : Graph = Graph(this.entries.Remove(id))
    member this.addSeveral (es : Entry list) : Graph = 
      match es with
      | [] -> this
      | h :: t -> (this.add h).addSeveral t
    member this.filter (p : Entry -> bool) : Graph =
      let mp = fun id e -> p e
      Graph(Map.filter mp this.entries)
  end 