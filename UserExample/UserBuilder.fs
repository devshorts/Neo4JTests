namespace UserExample

open Neo4jClient
open Neo4JBase

module UserBuilder = 

    let (%%) a b = (a, b)

    let buddy a = a %% { How = "buddy" }

    let coworker a = a %% { How = "coworker"}

    let conn = Connection("http://localhost:7474/db/data").connect()

    let makeRelation how = conn.client.CreateRelationship how
    
    let knows (user, relation) source = (source, Knows(user, relation)) |> makeRelation |> ignore

    let follows user source = (source, Follows(user)) |> makeRelation |> ignore
    
    let populate() =         

        let  anton  = { Name = "anton"; Handle = "devshorts" }   |> conn.create
        let  faisal = { Name = "faisal"; Handle = "fmansoor" }   |> conn.create
        let  carlo  = { Name = "carlo"; Handle = "c$$" }         |> conn.create
        let  mike   = { Name = "mike"; Handle = "pogs" }         |> conn.create
        let  khiem  = { Name = "khiem"; Handle = "lebowski" }    |> conn.create

        anton  |> knows (buddy faisal)
        faisal |> knows (buddy mike)
        mike   |> knows (buddy faisal)
        anton  |> knows (coworker khiem)
        khiem  |> knows (coworker carlo)
        khiem  |> knows (buddy anton)
        mike   |> knows (buddy carlo)

        anton  |> follows mike
        mike   |> follows khiem
        faisal |> follows carlo
        carlo  |> follows anton
        carlo  |> follows faisal
        carlo  |> follows mike
        carlo  |> follows carlo        

