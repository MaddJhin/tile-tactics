using UnityEngine;

public class HexGrid : MonoBehaviour {

    public int width = 6;
    public int height = 6;

    public HexCell cellPrefab;

    HexCell[] cells;

    void Awake()
    {
        // Define cells size based on width and height of the desired grid
        cells = new HexCell[height * width];

        // Invoke create cell for as as long and wide as the width and height
        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    // Instantiate a cell by passing it a position in the x and z planes and an index id to store in teh HexCell array
    void CreateCell(int x, int z, int i)
    {
        // Position from the parameters using 10 as offset based on the dfault plane size
        // TO DO: Change magic numbers
        Vector3 position;
        position.x = x * 10f;
        position.y = 0f;
        position.z = z * 10f;

        // Instantiate, add to HexCell array and set parent and local position 
        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }

}
