# HD Toon ShaderGraph
Toon Shader for Unity HDRP (High Definition Rendering Pipeline).

## How To Use
- Add "ToonShaderLightSettings.cs" to main light(Directional Light) in scene
- Attach HDToon material to mesh.



# Wind Waker Sea

Recreating wind waker sea in shader graph same appearence and some logic, we can determine an object to bee at see level no matter the sea movement, this is how the boat in windwaker its always on top of the sea, even with sea movement, only supports one object, but can be extended to work with multiple object in the case of many enemy boats on the surroundings.


https://user-images.githubusercontent.com/22778259/143433071-bd35dced-0e00-469f-866d-8a00e6f5880a.mp4


## How To Use

- Place Material to a high vertex plane.
- put cube blob script to objet you want to maintain at sea level, only supports one object for now, if you want to support more, you need to add their position to the taylor series manually.
- On the material you can set sea intesity options.
![image](https://user-images.githubusercontent.com/22778259/143432826-44545711-d836-4aa0-93e2-1e6634245298.png)

# Water with refraction distortion technic using shader graph.

Using Scene color node to distort background to recreate refraction effect on water.

![image](https://user-images.githubusercontent.com/22778259/143434670-a868dd63-a1cd-4dcb-8574-e67991c2e8f1.png)


https://user-images.githubusercontent.com/22778259/143438716-6a4b8f81-6694-4aa6-9f26-9b1ce9936029.mp4




## Licence
MIT Licence
