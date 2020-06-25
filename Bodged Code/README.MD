This folder contains various code hacks or badly written pieces of software which were used to help with this project.

* Zone Builder Edits

A few source code files of modifications made to [Zone Builder](https://git.magicalgirl.moe/MascaraSnake/ZoneBuilder/tree/e8e87bf8f184318bce73fb6cb129b9a7203b344e) with the intent of making the OBJ export slightly less broken (by removing the pathetic attempt to "optimise" the terrain export) and allowing me to dump out a list of the objects, their positions and their rotations. Due to not understanding how the ExportToObj function worked, I always just hijacked the OBJ Export code to print that list and simply commented my addition out whenever I needed to export terrain.

* Zone Builder Things to S06

This was a piece of software that took a list saved into a file produced by my Zone Builder code edits, which would convert an SRB2 object's type and position to an equivalent '06 object. Object definitions had to be added manually and the filepaths were all hardcoded and I just commented lines out whenever I didn't need them or was using this to automate other tasks. 