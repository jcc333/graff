namespace graff.primitives.graph

open System
open System.Collections

type Id = int64

type PropertySet = Map<string, string>

type Node = 
  { label : Id
    properties : PropertySet }

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

type Graph = Map<Node, Entry>