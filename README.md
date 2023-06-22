# DecodeUTF8
> DecodeUTF8 is a user-friendly API designed to effortlessly decode UTF8 character escapes. It simplifies the process of translating encoded characters into their respective UTF8 representations.
> For instance, if you have the character "á" (a with an acute accent), its encoded representation would be "\u00E1". With DecodeUTF8, you can seamlessly convert such encoded characters into their
> original form with ease.

[![NPM Version][npm-image]][npm-url]
[![Build Status][travis-image]][travis-url]
[![Downloads Stats][npm-downloads]][npm-url]

One to two paragraph statement about your product and what it does.

![](header.png)



## Usage example

DecodeUTF8 is an API that allows you to effortlessly decode UTF8 character escapes. It operates through a GET request, where you provide the encoded text as the "encodedText" parameter. The API will respond with a JSON object containing the "decodedText" property, which holds the decoded value.

For instance, if you send a GET request with the parameter "\u00c1 \u00c9 \u00cd \u00d3 \u00da \u00c7", the API will return a JSON object in the following format:

{
"decodedText": "Á É Í Ó Ú Ç"
}

## Development setup


Install ASP.NET Core 7.0.8 or a compatible version. You can download it from the official Microsoft website.

## Release History


* 0.0.1
    * Work in progress - Firts version





<!-- Markdown link & img dfn's -->
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)


