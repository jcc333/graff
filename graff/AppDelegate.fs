namespace graff

open System
open System.Drawing
open MonoMac.ObjCRuntime
open MonoMac.Foundation
open MonoMac.AppKit

[<Register("AppDelegate")>]
type AppDelegate() = 
  inherit NSApplicationDelegate()
  [<DefaultValue>]
  val mutable mainWindowController : graff.MainWindowController
  override x.FinishedLaunching(notification) = 
    let mainWindowController = new graff.MainWindowController()
    mainWindowController.Window.MakeKeyAndOrderFront(x)

module main = 
  [<EntryPoint>]
  let main args = 
    printfn ("Hello world")
    0