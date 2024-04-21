keytool -genkey -v -keystore key.keystore -alias RoLalias -keyalg RSA -keysize 2048 -validity 10000

<PropertyGroup Condition="$(TargetFramework.Contains('-android')) and '$(Configuration)' == Release">
		<AndroidKeyStore>true</AndroidKeyStore>
		<AndroidSigningKeyStore>..\key.keystore</AndroidSigningKeyStore>
		<AndroidSigningStorePass>23.Tuhanlah</AndroidSigningStorePass>
		<AndroidSigningKeyAlias>RoLalias</AndroidSigningKeyAlias>
		<AndroidSigningKeyPass>23.Tuhanlah</AndroidSigningKeyPass>
	</PropertyGroup>