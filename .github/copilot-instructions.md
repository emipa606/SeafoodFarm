# Copilot Instructions for RimWorld Mod: Seafood Farm

### Mod Overview and Purpose
The **Seafood Farm** mod is an addon for the **Neolithic Scavenging** mod. Its purpose is to simulate vertical ocean farming in RimWorld, providing players with a sustainable and immersive way to cultivate ocean resources such as Kelp, Seaweed, Mussels, and Oysters. These ocean farms can be placed on any ocean tile and will automatically spawn resources every seven days. Additionally, players can enhance their yield by strategically placing the farms near fish-nets, traps, piers, or even sewage outlets from compatible mods.

### Key Features and Systems
- **Ocean Farms**: Constructs that spawn ocean-based resources, adding depth and variety to the gameplay.
- **Resource Growth**: Yields increase over time and are influenced by placement proximity to certain structures.
- **Compatibility**: Works in conjunction with other mods, such as Fish Traps, FishIndustry, and Dubs Bad Hygiene, among others, enabling enhanced inter-mod synergy.

### Coding Patterns and Conventions
- **Project Structure**: The mod uses the .NET Framework version 4.7.2 and 4.8, with clearly defined class structures.
- **Naming Conventions**: Classes and methods use PascalCase, while private fields within classes use camelCase.
- **Organization**: Each class is separated into functional components, making modifications and extensions straightforward.

### XML Integration
Although the base description does not detail XML usage, it is crucial for defining various RimWorld mod elements such as item definitions, recipes, and structure placements. Ensure your XML files for item definitions are correctly structured and linked with C# components via `Def` classes or equivalent references.

### Harmony Patching
Harmony is a library that facilitates runtime code modifications. To implement Harmony patches:
1. **Reference Harmony**: Ensure Harmony is included in your project references.
2. **Patch Methods**: Identify and patch relevant methods of the core RimWorld assemblies to introduce custom behavior without rewriting base game code.
3. **Annotated Patching**: Use `[HarmonyPatch]` attributes to target and modify game behavior, such as altering resource spawn rates or placement rules.

### Suggestions for Copilot
- **Class Expansions**: Utilize Copilot to generate boilerplate code for new classes you might need, such as additional resource types or farm variants.
- **Method Implementations**: Leverage Copilot to flesh out unimplemented methods, particularly those interfacing with Harmony patches.
- **XML Definitions**: Prompt Copilot to draft templates for XML definitions required for new items or resources introduced by the mod.
- **Performance Optimization**: Suggest Copilot review and propose optimizations primarily within the `SpawnItems` method's logic to ensure performance efficacy, especially for mod compatibility scenarios.
- **Code Comments**: Use Copilot to help maintain clear and descriptive comments throughout your code, aiding in long-term maintainability and community contributions.

By adhering to these guidelines, Copilot can assist in developing a robust and well-integrated mod for RimWorld, enhancing the overall player experience.
