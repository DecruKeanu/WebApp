<p align="center">
<img src="https://www.digitalartsandentertainment.be/dae/images/DAE_headerLogo.png" length=20% width=20%>
</p>
<h1 align="center">Windows Application</h1>
<p align="center">A project made during my education at <a href="https://www.digitalartsandentertainment.be/">DAE</a>, to showcase my ability to make a Windows application using Microsoft's WPF framework.<br>
<sub>By <a href="https://keanudecru.myportfolio.com/">Keanu Decru</a></sub></p>

***

# Introduction
This application is an assignment to showcase my ability to use the following technologies and concepts:
 * WPF
 * REST API (json)
 * XAML (UI design)
 * C#
 * MVVM
## Technical requirements
Because this project was made as an assignment, it has to adhere to some technical requirements set by the teachers. These technical requirements are:
 * Usage of the MVVM pattern
 * 2 different pages on 1 window, with a button to navigate between then
 * Usage of a REST API
 * Ability to use local a version (downloaded version of API)
 * Good code quality
# The Application
## Basic concept
I have chosen to make an app that displays an encyclopedia of in game items in the game *The Legend of Zelda: Breath of the Wild*. I made this decision partially out of personal interest, and partially out of relevance to my education (Game Development).
## API
I used the [Hyrule Compendium API](https://github.com/gadhagod/Hyrule-Compendium-API). This API was chosen out of personal interest, and because it matches the expected complexity for this assignment.
## Design Choices
While designing the UI for this project, my goal was to try to replicate the original UI of the in game compendium. I did this because the course was focussed on the implementation and functionality, rather than the design of the UI.
# Implementation
## Good C# practices
While implementing this system, I wanted to keep my code clean and readable by using common good practices from the C# world.

One example of this is the way I structured the data provided by the API. I used interfaces to ensure certain data provides certain values, while making it easy to combine these types of data in more complex classes:
```cs
public interface IHasDrops
{
    List<string> Drops { get; }
}

public interface IHasHeartsRecovered
{
    string HeartsRecovered { get; }
}

public interface IHasCookingEffects
{
    string CookingEffects { get; }
}

public interface IHasAttack
{
    string Attack { get; }
}

public interface IHasDefense
{
    string Defense { get; }
}
```
Example implementation of these interfaces:
```cs
public sealed class MaterialEntry : DataEntry, IHasHeartsRecovered, IHasCookingEffects
{
    [JsonProperty(PropertyName = "hearts_recovered")]
    public string HeartsRecovered { get; set; }

    [JsonProperty(PropertyName = "cooking_effect")]
    public string CookingEffects { get; set; }
}
```
## MVVM
I structured this project using the [MVVM](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel) (Model-View-ViewModel) pattern. This ensures that code is decoupled, preventing monolith classes end ensuring that my code is readable and maintainable.

This is a simplified view of the general structure of my project:
```
Project
├─View
│ └─SomePage.xaml
├─ViewModel
│ └─SomeDataFileVM.cs
├─Model
│ └─SomeDataFile.cs
├─Repository
│ └─Repository.cs
└─Resources
  └─ExampleResourceFile.png
  ```
# Conclusion
This project was a great introduction to Windows application development development for me. While I still have a lot to learn, this project gave me a good understanding of some of the technologies in this field. WPF, MMVM and json REST APIs are great starting point for me to expand my skills and learn more about this kind of development. Due to the usage of the MVVM pattern, there are certain similatities between this project and full-stack web development, I'm eager to explore this world a bit more with some more personal research.
