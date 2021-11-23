Imports System.Security.Cryptography
Imports System.Text

'Fragment kodu ze strony
'http://www.dreamincode.net/forums/topic/171440-encrypting-xml/

'Funkcja Encrypt służy do szyfrowania
'Decrypt do odszyfrowania

Public Class CryptoZ

    Private Shared DES As New TripleDESCryptoServiceProvider

    Private Shared MD5 As New MD5CryptoServiceProvider

    Public Shared Function MD5Hash(ByVal value As String) As Byte()

        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))

    End Function

    Public Shared Function Encrypt(ByVal stringToEncrypt As String, ByVal key As String) As String

        DES.Key = MD5Hash(key)

        DES.Mode = CipherMode.ECB

        Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)

        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))

    End Function

    Public Shared Function Decrypt(ByVal encryptedString As String, ByVal key As String) As String

        Try

            DES.Key = MD5Hash(key)

            DES.Mode = CipherMode.ECB

            Dim Buffer As Byte() = Convert.FromBase64String(encryptedString)

            Return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))

        Catch

            MsgBox("Wrong Key Number, decryption not available!")

            Return Nothing

        End Try

    End Function

End Class