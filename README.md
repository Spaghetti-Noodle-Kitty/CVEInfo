# CVEInfo
##### Search NISTs NVD database for a provided CVE-Number

## What is this?
> This project is a small utility, to quickly learn about a CVE and its attributes such as:
> * The Severity Score
> * The main Attack-Vector & Attack requirements
> * Possible Impacts
> * A description of the CVE (if u want)

## Anyways, how do I use this?
> _first off, i recommend adding this projects build to your path variable for easier access_
>
> You start the program through a Shell of your choosing (CMD, PowerShell, Windows Terminal) with the following command:
>
> __Either__ ```CVEInfo.exe _CVE-Number e.g. CVE-2022-69420_```
>
> __Or__ ```cveinfo _CVE-Number e.g. CVE-2022-69420_```
>
> Additionaly, if you want the CVE-Description aswell, start CVEInfo with a "-d" argument.
>
> ```cveinfo _CVE-Number e.g. CVE-2022-69420_ -d```

## API Key Information
> As written [here](https://nvd.nist.gov/developers/start-here), the NVD-API has rate-limits built in.
> If you want higher limits, you need to modify the source code yourself.
> To use your own API-Key, add it in ```Program.cs``` in the variable ```API_KEY.```

## A small closing statement
> * This mald-fest is provided as is.
> * I take no responsibility, for any data shown by CVEInfo, the data gathered is straight from the NVDs API.
> * Feel free to use any of the code in CVEInfo if you want to
> * _(Please credit me if you actually use some of this code_ :point_right::point_left:_)_
