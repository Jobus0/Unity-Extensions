# Unity Extensions
Handy extensions for general Unity development.

## About
This is a fairly large collection of extensions that I've accumulated over many years of Unity development. The goal is to reduce boilerplate code and simplify development without adding too much clutter, while being consistent with Unity's API style.

Nearly all extensions have XML documentation, except for where the method name alone is clear enough.

The extensions were written with performance in mind, and the few unavoidably slow methods that use [reflection](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection) have explicit warnings in their XML documentation.

### Classes
- [MathExtensions](Runtime/MathExtensions.cs)
    - Focuses mainly on vectors, adding shorthand functions such as:
        - `vector.WithY(0f)` for `new Vector3(vector.x, 0f, vector.z)`.
        - `vector.OnlyY()` for `new Vector3(0f, vector.y, 0f)`.
        - `vector.XZ()` for `new Vector2(vector.x, vector.z)`.
- [EnumerableExtensions](Runtime/EnumerableExtensions.cs)
    - `list.Random()` returns a random object from the list (`list[UnityEngine.Random.Range(0, list.Count)]`).
    - `list.Average()` like LINQ's Average() function (get the average of all values in a list) but for Vector3 and Quaternion.
    - `list.RandomizedOrder()` to enumerate a list in a randomized order (shorthand for `list.OrderBy(item => UnityEngine.Random.value)`).
    - Simple enumeration shorthands: `list.AddAll(otherList)`, `list.RemoveAll(otherList)`, `list.ContainsAll(otherList)`.
- [BitwiseExtensions](Runtime/BitwiseExtensions.cs)
    - `enum.CountFlags()` used on layer masks or other bit field (FlagsAttribute) enums to check how many flags they contain (i.e., how many bits equal 1).
- [LayerExtensions](Runtime/LayerExtensions.cs)
    - `layerMask.HasLayer("Water")` for `layerMask == (layerMask | (1 << LayerMask.NameToLayer("Water")))`.
    - `gameObject.SetLayer("Water", includeChildren: true)` for recursively setting gameObject and its children's layers.
- [GameObjectExtensions](Runtime/GameObjectExtensions.cs)
    - GetComponent overload with an index parameter, e.g. `gameObject.GetComponent<Collider>(2)` to get the third Collider component.
- [TransformExtensions](Runtime/TransformExtensions.cs)
    - `transform.GetPath()` gets the hierarchical path of the transform, e.g. "Player/Armature/Spine/LeftArm/LeftHand".
    - `transform.SetPath("Player/Armature/Spine/LeftArm/LeftHand")` sets the hierarchical path to where the transform should be parented.
- [ConstraintExtensions](Runtime/ConstraintExtensions.cs)
    - `constraint.AddSource(transform)` for `constraint.AddSource(new ConstraintSource {sourceTransform = transform, weight = 1f))`.
    - `constraint.AddSourceWithCurrentOffsets(transform)` for adding source while doing all the transform translation math to keep the source transform in its current position and rotation.
- [ColorExtensions](Runtime/ColorExtensions.cs)
    - `color.WithAlpha(0.5f)` for `new Color(color.r, color.g, color.b, 0.5f)`.
    - `color.WithAlphaRelative(0.5f)` for `new Color(color.r, color.g, color.b, color.a*0.5f)`.
- [StringExtensions](Runtime/StringExtensions.cs)
    - Rich text color with `string.WithColor("#ff0000")` and `string.WithColor(Color.red)`.
    - `string.SplitPascalCase()` turns pascal case strings like "AllYourBase" into "All Your Base".
    - `string.UppercaseFirstLetter()`
- [StringBuilderExtensions](Runtime/StringBuilderExtensions.cs)
    - Rich text color with `stringBuilder.Append("Foo", "#ff0000")` and `stringBuilder.Append("Foo", Color.red)`.
    - `stringBuilder.TrimEnd()` with respective overloads identical to `string.TrimEnd()`.
- [UIToolkitExtensions](Runtime/UIToolkitExtensions.cs)
    - `element.SetActive(false)` toggles the element on and off much like `GameObject.SetActive()` does, by setting the 'display' style to Flex or None, and also sends a ElementActiveEvent for you to register callbacks for.
    - `element.GetRoot()` recursively traverses `element.parent` and returns the root parent.

##### The inner points are just a few notable examples. Please check the linked files for more.

## Installation
1. In Unity's Package Manager, press the "+" button.
2. Select "Add package from git URL...".
3. Put in: https://github.com/Jobus0/Unity-Extensions.git
