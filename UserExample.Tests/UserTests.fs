namespace UserExample.Tests

open FsUnit
open NUnit.Framework
open UserExample
open System

module UserTests = 

    [<Test>]
    let pop() = 
        UserBuilder.populate()

        Assert.IsTrue true
