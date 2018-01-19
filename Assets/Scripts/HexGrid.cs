using UnityEngine;

public class HexGrid : MonoBehaviour {

    public int width = 6;
    public int height = 6;

    public HexCell cellPrefab;

    HexMesh hexMesh;
    HexCell[] cells;

    void Awake()
    {
        hexMesh = GetComponentInChildren<HexMesh>();

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
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        // Instantiate, add to HexCell array and set parent and local position 
        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }

}
