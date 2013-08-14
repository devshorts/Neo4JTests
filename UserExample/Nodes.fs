namespace UserExample

[<AutoOpen>]
module Nodes = 

    [<CLIMutable>]
    type User = { Name:string; Handle:string }

    [<CLIMutable>]
    type RelationshipType = { How : string }
    
