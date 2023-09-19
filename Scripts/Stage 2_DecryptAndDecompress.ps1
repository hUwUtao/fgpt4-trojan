$decryptionFunctionNames = 'FromBase64String','Decompress','CreateDecryptor','Split','CopyTo','TransformFinalBlock'

# Decryption key and IV
$key = [System.Convert]::FromBase64String('34lAyVlbw77ON9xSh1j1eo4jVjfrXHRRypmTO1BVv5U=')
$iv = [System.Convert]::FromBase64String('sclHJpu2svJEHkdRgZJIug==')

# AES decryption function
function Decrypt-AES {
  param($ciphertext)
  
  $aes = [System.Security.Cryptography.Aes]::Create()
  $aes.Mode = [System.Security.Cryptography.CipherMode]::CBC
  $aes.Padding = [System.Security.Cryptography.PaddingMode]::PKCS7
  $aes.Key = $key
  $aes.IV = $iv

  $decryptor = $aes.CreateDecryptor()  
  $plaintext = $decryptor.TransformFinalBlock($ciphertext, 0, $ciphertext.Length)

  $decryptor.Dispose()
  $aes.Dispose()

  return $plaintext
}

# Decompression function  
function Decompress-GZip {
  param($compressedData)
  
  $inputStream = New-Object System.IO.MemoryStream(, $compressedData)
  $outputStream = New-Object System.IO.MemoryStream
    
  $gzipStream = New-Object System.IO.Compression.GzipStream($inputStream, [IO.Compression.CompressionMode]::Decompress)
  $gzipStream.CopyTo($outputStream)

  $gzipStream.Dispose()
  $inputStream.Dispose()

  return $outputStream.ToArray()  
}

# Read base64 encoded payloads
$payload1 = Decrypt-AES(Get-Content '.\payload1.enc' -Encoding byte)
$payload2 = Decrypt-AES(Get-Content '.\payload2.enc' -Encoding byte)

# Decrypt and decompress payloads
# $payload1 = Decompress-GZip(Decrypt-AES $payload1)
# $payload2 = Decompress-GZip(Decrypt-AES $payload2)

# Extract payloads to files
[System.IO.File]::WriteAllBytes('payload1.gz', $payload1)
[System.IO.File]::WriteAllBytes('payload2.gz', $payload2)