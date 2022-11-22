TriangleMeshEditor
Author: Jakub Wasilewski

Instruction:
In the Files folder there are sample files that should be used to run the application:
Folders:
-OBJ - stores files with the extension .obj
- NormalMaps - sample files with normal maps
- Textures - collection of textures.

To load a file, press Lupe at: Choose File --->.
In the Box dialog, select one of the files from the OBJ folder.
In order to open the file, press the GENERATE button.

In the upper right corner, next to FPS, there is a button to return to the previous MENU, a section with file selection
and history of opened files. You can open a history file by selecting it and clicking GENERATE.

The application allows you to rotate the object.
- To rotate the object, press the left mouse button and, while holding it, move it to the right and left
- Zoom use mouse scroll

In the upper left corner we have 3 main sections

-Environment (Sun)
-Details (notebook with lupe)
- Instruction (open book)

By default, after starting the application, we are greeted by the Environment tab. (Sun)

Details: (I'll start with this as Environment extends some features from here)
-------------------------------------------------- ------
In ObjectDetails there are:
- TriangleMesh - draws a mesh of triangles
- Vertex draws vertices
- Faces Normal - draws a normal for each face (faces)
- Vertex Normal - draws the normals read from the file for each vertex.

It is possible to select all options.


environments:
-------------------
- Light Position: allows you to control the light
  There are also 3 tabs here
Radial - controlling the light in a circle to set the radius and distance of the light from the object.
XYZ - light control along the XYZ axes
Animation - select one of the tiles and activate the animations by pressing the PLAY button.
there is a Zoom for animation button here - zoom out the object so as to maintain the quality and increase the efficiency of the animation.
during the animation we can do everything except move the object.

- Properties
section allows you to customize the environment, there are 2 sections:
- Object Properties:
selectable coloring mode or normal or barycentric vector interpolation (vertex interpolation)
- vertex normal Size - allows you to modify the length of normal vectors in the preview (if visible in Details)
- Face Normal Size - same as above.
- possible change of the color of the object.
- Light Properties:
-light color - change the color of the light.
- Coeficients - change of ks kd m coefficients
- textures:
Press load Texture, select a file from Textures, and press Set Texture
- Normal Map:
 Press load Map, select the NormalMaps file, and press Set Map