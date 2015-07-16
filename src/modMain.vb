#If False Then
Copyright © 2015 Russell Dillin

This file is part of validatingCCNums.

validatingCCNums is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

validatingCCNums is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with validatingCCNums.  If not, see <http://www.gnu.org/licenses/>.
#End If

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
