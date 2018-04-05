The **BI/public** branch in this fork of this code is managed by [Business Integrations Ltd](https://github.com/BusinessIntegrations).

A changelog is appended at the end of this file. Further information on our coding standards and approach are detailed [here](https://businessintegrations.github.io/).

***
 
# Orchard Simple Analytics Readme

## Project Description

Orchard module for simply configuring an analytics (e.g. Google Analytics) script for an Orchard site.

## Documentation

Just add the analytics script under the site Settings. This script (wrapped into a script tag) will be injected into the head of your site. You can also configure whether to inject the script on the admin site or not.

**Warning:** this module uses infoset storage for efficiently store the configuration. This also means it's only compatible from Orchard 1.8 (or newer).

The module is also available for [DotNest](http://dotnest.com/) sites.

The module's source is available in two public source repositories, automatically mirrored in both directions with [Git-hg Mirror](https://githgmirror.com):

- [https://bitbucket.org/Lombiq/orchard-simple-analytics](https://bitbucket.org/Lombiq/orchard-simple-analytics) (Mercurial repository)
- [https://github.com/Lombiq/Orchard-Simple-Analytics](https://github.com/Lombiq/Orchard-Simple-Analytics) (Git repository)

Bug reports, feature requests and comments are warmly welcome, **please do so via GitHub**.
Feel free to send pull requests too, no matter which source repository you choose for this purpose.

This project is developed by [Lombiq Technologies Ltd](http://lombiq.com/). Commercial-grade support is available through Lombiq.

***

## Business Integrations Changelog

1. Module rework 2018-04-04  
   * Code tidy
   * Update readme.md