Very simple Feature Toggles (http://martinfowler.com/bliki/FeatureToggle.html) implementation using the AppContext class that comes with .NET 4.6 and greater.

Add the following to the your app/web.config
	<configuration>
		<configSection> 
			<section name="features"
				type="FeatureToggles.FeaturesConfigurationSection, 
				FeatureToggles, 
				Version=1.0.0.0, 
				Culture=neutral"
				restartOnExternalChanges="true"
				requirePermission="false"
			/>
		</configSection> 

		<features activate="MyFeature1, MyFeature2, MyFeature3", allow-overrides="true">
			<feature name="MyFeature3" activated="false"/>
			<feature name="MyFeature4" activated="true"/>
		</features>
	</configuration>

Toggles in the 'activate' attribute are set to true.
Toggles for individual feature elements can be used as an alternative mechanism.

When allow-overrides is "false" a ConfigurationErrorException is thrown if the same feature toggle is set twice

  use 

  Features.State("MyFeature1") to retrieve flag state or
  
  Features.List() to retrieve all flags and state.

