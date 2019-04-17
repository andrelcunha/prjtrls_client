using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using UnityEngine.UI;

public class Uteis : MonoBehaviour
{

    public static List<int> GetSequence(int tamanho, int max) {
        int intSeed = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        System.Random random = new System.Random(intSeed);

        return Enumerable.Range(max - (tamanho - 1), tamanho).OrderBy(ob => random.Next()).ToList<int>();
    }

    public static IEnumerable Delay(float Count) {
        yield return new WaitForSeconds(Count);
    }

    public static string ObterSeparador() {
        return Path.DirectorySeparatorChar.ToString();
    }

    public static string LerArquivo(string Arquivo) {
        string strTextoArquivo = "";

        using (StreamReader sr = new StreamReader(Arquivo)) {
            strTextoArquivo = sr.ReadToEnd();
            sr.Close();
        }
        return strTextoArquivo;
    }

    public static Sprite CarregarNovoSprite(string Caminho, float PixelsPorUnidade = 100.0f, SpriteMeshType TipoSprite = SpriteMeshType.Tight) {

        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

        Sprite sprNovoSprite = new Sprite();
        Texture2D SpriteTexture = CarregarTextura(Caminho);
        sprNovoSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPorUnidade, 0, TipoSprite);

        return sprNovoSprite;
    }

    public static Texture2D CarregarTextura(string Caminho) {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D textura2D;
        byte[] byteDadosArquivo;

        if (File.Exists(Caminho)) {
            byteDadosArquivo = File.ReadAllBytes(Caminho);
            textura2D = new Texture2D(2, 2);           // Create new "empty" texture

            if (textura2D.LoadImage(byteDadosArquivo))           // Load the imagedata into the texture (size is set automatically)
            {
                return textura2D;                 // If data = readable -> return texture
            }
        }

        return null;                     // Return null if load failed
    }

    public static void MostrarOcultar(GameObject Painel, bool Mostrar) {
        Image imgPainel = Painel.GetComponent<Image>();
        imgPainel.enabled = Mostrar;

        Image[] imgFilhos = Painel.GetComponentsInChildren<Image>();

        foreach (Image img in imgFilhos) {
            img.enabled = Mostrar;
        }

        Text[] txtFilhos = Painel.GetComponentsInChildren<Text>();
        foreach (Text txt in txtFilhos) {
            txt.enabled = Mostrar;
        }

        Button[] btnFilhos = Painel.GetComponentsInChildren<Button>();
        foreach (Button btn in btnFilhos) {
            btn.enabled = Mostrar;
        }
    }

    public static string LoadJson(string fileName) {
        string filePath = Path.Combine("Json", fileName);
        //Debug.Log("Path: " + filePath);
        try {
            TextAsset targetFile = Resources.Load<TextAsset>(filePath);
            //Debug.Log("Json: " + targetFile);
            return targetFile.text;
            //Config objConfig = JsonUtility.FromJson<Config>(targetFile.text);
        } catch {
            Debug.LogWarning("File not Found!");
        }
        return "";
    }

	public static void SaveJson(string fileName, string dataAsJson)
    {
		string filePath = Path.Combine(Application.dataPath,"Resources","Json", fileName+".json");
        //Debug.Log("Path: " + filePath);
        try
        {
			File.WriteAllText(filePath, dataAsJson);
			//TextAsset targetFile = Resources.Load<TextAsset>(filePath);
            //Debug.Log("Json: " + targetFile);
            //return targetFile.text;
            //Config objConfig = JsonUtility.FromJson<Config>(targetFile.text);
        }
        catch
        {
			Debug.LogWarningFormat("File {0} not Found!", filePath);
        }
        return;
    }
}
