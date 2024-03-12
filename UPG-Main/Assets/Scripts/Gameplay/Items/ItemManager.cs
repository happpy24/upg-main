using System.IO;
using UnityEngine;
using UnityEngine.UI;

internal class ItemManager 
{
    internal int cost;
    internal string itemName;
    internal string desc;
    protected Sprite sprite;
    internal string path;
    protected Player player;

    public ItemManager(Player player)
    {
        this.player = player;
    }
    internal virtual void UseItem()
    {

    }
    internal void GetInfo(Image image)
    {
        Debug.Log(path);
        Texture2D spriteTexture = LoadTexture(path);
        if (spriteTexture != null)
        {
            Rect rect = new Rect(0, 0, spriteTexture.width, spriteTexture.height);
            sprite = Sprite.Create(spriteTexture, rect, Vector2.one * 0.5f);
            Debug.Log(image.name);
            image.sprite = sprite;
        }
    }
    public Texture2D LoadTexture(string spritePath)
    {
        Texture2D Tex2D;
        byte[] FileData;        
        if (File.Exists(spritePath))
        {
            FileData = File.ReadAllBytes(spritePath);
            Tex2D = new Texture2D(2, 2);          
            if (Tex2D.LoadImage(FileData))         
                return Tex2D;
        }
        return null;
    }
}
