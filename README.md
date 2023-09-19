# #FreeGPT4 Trojan
#### The only thing it does is modifying some of your unecessary features, and i did took times to rev-engineering it
#### And I will never do that again.

This was a random suspicious file found in the wild

[Alt text](Gallery/ads.png)

It goes to
[this google drive link](https://drive.google.com/file/d/14RSdol3jKmLsV5QinH-h2Xn6xmsScFVx/view?fbclid=IwAR0XXFpZFQQVtVzAsFCf4WFpxzpIQEaH6y-wKzjIIKCIDuybno26nxfH_0k) by `"Marketing H Digiatal" <bipvailon123@gmail.com>`

## Payload

The payload is a 2 section in a string, pulled into a variable. Both seperated by `::`, with base64 pattern

The script then copy powershell to its workdir (Get-Content wont work normaly if not). Then it load the string into 2 part, debase64 it, unencrypted it with `AES` and decompress it with `Gzip`. 

## Binary

2 files have the exact same size wth. well it is a dotnet 4.0 program. i decompiled with dnspy and notice it is obfuscated (not a real problem, but it is inexportable though). de4dot does the thing.

as a native regexian, i magicked all the obfuscation out of existence. so ugh, it clearly do something with dlls, and i figured out why...

> List of the string used in the program. Side-product of regex extraction.
```
kernel32.dll
CloseHandle
kernel32.dll
FreeLibrary
kernel32.dll
VirtualProtect
kernel32.dll
CreateFileA
kernel32.dll
CreateFileMappingA
kernel32.dll
MapViewOfFile
msvcrt.dll
memcpy
psapi.dll
GetModuleInformation
kernel32.dll
IsWow64Process
ntdll.dll
kernel32.dll
amsi.dll
AmsiScanBuffer
uFcAB4DD
uFcAB4DCGAA=
ntdll.dll
EtwEventWrite
ww==
whQA
C:\Windows\System32\
C:\Windows\SysWOW64\
```

ok so well it is a little bit trickier when

```c#
Math.Abs(-(-(-Math.Min(3, Math.Abs(int.MaxValue)))))
```

so it just `3` in unsigned but with extra stupid step dear god.

## End

so thats all. I highly rated this, as it is slightly better than `brum/test2` stealer, because you did actually know how to payload it the correct way, and not agressively compress it. Hope you the maker happy because you wasted me 3 hour to decomp this, and extra 30min to write this too.