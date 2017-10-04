mkdir EPPlus\bin\package
cd EPPlus\bin\package
del * /q
..\..\..\nuget pack ..\..\EPPlusSK.nuspec
..\..\..\nuget push *.nupkg -Source https://www.nuget.org/api/v2/package
cd..
cd..
cd..
