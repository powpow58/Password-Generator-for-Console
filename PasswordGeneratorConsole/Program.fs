// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

type Password() =
    member x.CreateRandomPassword(?length: int) =
        let length = defaultArg length 15
        // Create a string of characters, numbers, special characters that allowed in the password
        let validChars =
            "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-"

        let random = Random()
        // Select one random character at a time from the string
        // and create an array of chars
        String.Concat([| for i in 1 .. length -> validChars.[random.Next(0, validChars.Length)] |])

    member x.CreateRandomPasswordWithRandomLength(?length: int) =
        let length = defaultArg length 15
        // Create a string of characters, numbers, special characters that allowed in the password
        let validChars =
            "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-"

        let random = Random()

        // Minimum size 8. Max size is number of all allowed chars.
        let size = random.Next(8, validChars.Length)

        // Select one random character at a time from the string
        // and create an array of chars
        String.Concat([ for i in 1 .. size -> validChars.[random.Next(0, validChars.Length)] ])

[<EntryPoint>]
let main argv =
    let password = Password()
    printfn $"{password.CreateRandomPassword()}"
    printfn $"{password.CreateRandomPassword 10}"
    printfn $"{password.CreateRandomPassword 30}"

    printfn $"{password.CreateRandomPasswordWithRandomLength()}"
    0
