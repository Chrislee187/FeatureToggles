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

  <features names="MyFeature1, MyFeature2, MyFeature3">
    <feature name="MyFeature3" activated="false"/>
    <feature name="MyFeature4" activated="true"/>
  </features>