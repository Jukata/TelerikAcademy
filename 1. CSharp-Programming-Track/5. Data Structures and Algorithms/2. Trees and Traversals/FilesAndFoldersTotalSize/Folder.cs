using System;
using System.Collections.Generic;

public class Folder
{
    public string Name { get; set; }
    public IList<File> Files { get; set; }
    public IList<Folder> ChildFolders { get; set; }

    public Folder(string name)
    {
        this.Name = name;
        this.Files = new List<File>();
        this.ChildFolders = new List<Folder>();
    }

    public void AddFile(File file)
    {
        this.Files.Add(file);
    }

    public void AddFolder(Folder childFolder)
    {
        this.ChildFolders.Add(childFolder);
    }

    public override string ToString()
    {
        return this.Name;
    }
}