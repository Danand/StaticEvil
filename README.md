# StaticEvil
[![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/danand/StaticEvil/blob/master/LICENSE.md)

If you heard about *need to clean up statics* – you know for what it is.

## How to install

### From remote repository
Add in `Packages/manifest.json` to `dependencies`:
```javascript
"com.danand.staticevil": "https://github.com/Danand/StaticEvil.git#0.1.0-package-unity",
```

### From local path
<details>
	<summary>From local repository</summary>
	
	"com.danand.staticevil": "file:///D/repos/StaticEvil/.git#0.1.0-package-unity",
</details>

<details>
	<summary>From local working copy</summary>
	
	"com.danand.staticevil": "file:D:/repos/StaticEvil/Assets",
</details>

<details>
	<summary>What is the difference?</summary>
	<p>
		Local repository is resolved just like normal Git repository with optionally specified revision.<br />
		Local working copy is being copied "as is" into dependent project, without running any Git process.
	</p>
</details>

Don't forget to reference **StaticEvil** via Assemly Definitions.

## How to use
```csharp
private static Evil<ShopManager> shopManager;
```
