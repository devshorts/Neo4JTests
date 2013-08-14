namespace Neo4JBase

open System
open Neo4jClient

[<AutoOpen>]
module Connection = 
    type Connection (dbUrl) = 

        let graphConnection = new GraphClient(new Uri(dbUrl))

        member x.client = graphConnection

        member x.create item = x.client.Create item

        member x.connect() = 
            x.client.Connect()
            x