namespace Neo4JBase

open System
open Neo4jClient

[<AutoOpen>]
module RelationShips = 
    
    [<AbstractClass>]
    type Target<'T> (targetNode) = 

        inherit Relationship(targetNode)

        interface IRelationshipAllowingSourceNode<'T>

        interface IRelationshipAllowingTargetNode<'T>


    [<AbstractClass>]
    type TargetWithData<'T> (targetNode, data) = 

        inherit Relationship(targetNode, data)

        interface IRelationshipAllowingSourceNode<'T>

        interface IRelationshipAllowingTargetNode<'T>