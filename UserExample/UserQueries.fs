namespace UserExample

open Neo4JBase
open Neo4jClient
open Neo4jClient.Cypher
open System.Linq
open System.Collections.Generic

[<AutoOpen>]
module UserQueries = 

    let knows (conn:Connection) name = 
        let startBits = new Dictionary<string, obj>()
        startBits.["n"] <- "node(*)"

        conn.client.Cypher
                   .Start(startBits)
                   .Match("n-[:knows]->e")
                   .Where("HAS (n.Name)")
                   .AndWhere(fun n -> n.Name = name)
                   .Return<User>("e")
                   .Results
                   .Select(fun i -> i.Name)

