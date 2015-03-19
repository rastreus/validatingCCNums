Module modMain

	Sub Main()
		Dim input As String = New String("!")
		Dim validity As ValidateCC = New ValidateCC

		While True 'For Testing
			Console.WriteLine("Enter CC Num: ")
			input = Console.ReadLine
			If validity.validate(UInt64.Parse(input)) Then
				Console.WriteLine("VALID!")
			Else
				Console.WriteLine("INVALID!")
			End If
		End While
	End Sub
End Module
