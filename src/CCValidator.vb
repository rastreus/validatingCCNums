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

''' <summary>
''' Implimentation of the Luhn algoritm (https://en.wikipedia.org/wiki/Luhn_algorithm)
''' </summary>
''' <remarks>GRD-031915</remarks>
Public Class ValidateCC

	Private Function lastDigit(ByRef digit As UInt64) As UInt64
		Return (digit Mod 10)
	End Function

	Private Function dropLastDigit(ByRef ccNum As UInt64) As UInt64
		Return (ccNum \ 10)
	End Function

	Private Function toReverseDigits(ByRef ccNum As UInt64) As ArrayList
		Dim result As ArrayList = New ArrayList
		Return toReverseDigits(ccNum, result)
	End Function

	Private Function toReverseDigits(ByRef ccNum As UInt64, ByRef result As ArrayList) As ArrayList
		While ccNum > 0
			result.Add(lastDigit(ccNum))
			ccNum = dropLastDigit(ccNum)
		End While
		Return result
	End Function

	Private Function toDigits(ByRef ccNum As UInt64) As ArrayList
		Dim result As ArrayList = New ArrayList(toReverseDigits(ccNum))
		result.Reverse()
		Return result
	End Function

	Private Function doubleEveryOther(ByRef ccNumArrayList As ArrayList) As ArrayList
		Dim doubled As ArrayList = New ArrayList
		Dim index As Integer
		For index = 0 To ccNumArrayList.Count - 1
			If (index Mod 2 = 0) Then
				doubled.Add(ccNumArrayList.Item(index) * 2)
			Else
				doubled.Add(ccNumArrayList.Item(index))
			End If
		Next
		Return doubled
	End Function

	Private Function sumDigits(ByRef ccNumArrayList As ArrayList) As UInt64
		Dim result As UInt64 = 0
		For Each num In ccNumArrayList
			result = result + num
		Next
		Return result
	End Function

	''' <summary>
	''' Double the value of every second digit beginning from the right,
	''' add the digits of the doubled values and the undoubled digits from the original number.
	''' Calculate the remainder when the sum is divided by 10.
	''' If the result equals 0, then the number is valid.
	''' </summary>
	''' <param name="ccNum"></param>
	''' <returns>The validity of the credit card.</returns>
	''' <remarks>credit providers rely on a checksum formula called the Luhn Algorithm
	''' for distinguishing valid numbers from random collections of digits (or typing mistakes).</remarks>
	Public Function validate(ByRef ccNum As UInt64) As Boolean
		Dim bool As Boolean = False
		Dim digits As ArrayList = toDigits(ccNum)
		Dim doubled As ArrayList = doubleEveryOther(digits)
		Dim checksum As UInt64 = 0
		Dim index As Integer
		For index = 0 To doubled.Count - 1
			If (index Mod 2 = 0) Then
				checksum = checksum + sumDigits(toDigits(doubled.Item(index)))
			Else
				checksum = checksum + doubled.Item(index)
			End If
		Next
		If (checksum Mod 10 = 0) Then
			bool = True
		End If
		Return bool
	End Function
End Class
