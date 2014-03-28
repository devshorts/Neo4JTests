namespace Neo4JBase

open System
open Neo4jClient

[<AutoOpen>]
module RelationShips = 
    
    type Neo4JSourceANdTargetDefinition<'T> = 
        inherit IRelationshipAllowingSourceNode<'T>

        inherit IRelationshipAllowingTargetNode<'T>

    [<AbstractClass>]
    type Target<'T> (targetNode) = 

        inherit Relationship(targetNode)

        interface Neo4JSourceANdTargetDefinition<'T>


    [<AbstractClass>]
    type TargetWithData<'T> (targetNode, data) = 

        inherit Relationship(targetNode, data)

        interface Neo4JSourceANdTargetDefinition<'T>