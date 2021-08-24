using UnityEngine;

namespace SelectingTask
{
    public class CellCleaner : MonoBehaviour
    {
        public void RemoveAllCells()
        {
            var cells = GetComponentsInChildren<Cell>();

            foreach (var cell in cells)
            {
                Destroy(cell.gameObject);
            }
        }
    }
}