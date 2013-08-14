namespace UserExample.Tests

open FsUnit
open NUnit.Framework
open UserExample
open Neo4JBase
open System

module UserTests = 

    [<Test>]
    let pop() = 
        //UserBuilder.populate()

        let knowsUsers = UserQueries.knows UserBuilder.conn "anton"

        Assert.IsTrue true