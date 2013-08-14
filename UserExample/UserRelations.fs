namespace UserExample

open Neo4JBase
open Neo4jClient

[<AutoOpen>]
module UserRelations =
    
    type Knows (userNode, relationShipType : RelationshipType) = 

        inherit TargetWithData<User>(userNode, relationShipType)

        override x.RelationshipTypeKey with get() = "knows"


    type Follows (userNode) = 

        inherit Target<User>(userNode)

        override x.RelationshipTypeKey with get() = "follows"        