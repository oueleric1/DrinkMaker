dotnet clean .
dotnet restore .
dotnet build .
dotnet publish . -r linux-arm
pscp.exe -P 22 -r .\bin\Debug\netcoreapp3.1\linux-arm\publish\* pi@192.168.1.15:/home/pi/Development/DrinkDispenser