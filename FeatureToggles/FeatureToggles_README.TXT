Very simple Feature Toggles (http://martinfowler.com/bliki/FeatureToggle.html) implementation using the AppContext class that comes with .NET 4.6 and greater.

Add the following to the <configSection> of your app/web.config

    <section name="features"
          type="FeatureToggles.FeaturesConfigurationSection, 
          FeatureToggles, 
          Version=1.0.0.0, 
          Culture=neutral"
          restartOnExternalChanges="true"
          requirePermission="false"
    />

You may then add the following to your <configuration> section

  <features activate="MyFeature1, MyFeature2, MyFeature3", allow-overrides="true">
    <feature name="MyFeature3" activated="false"/> <!-- allow-overrides must be true or this will throw an exception -->
    <feature name="MyFeature4" activated="true"/>
  </features>

Toggles in the 'activate' attribute are set to true.
Toggles for individual feature elements can be used as an alternative mechanism.

When allow-overrides is "false" a ConfigurationErrorException is thrown if the same feature toggle is set twice
