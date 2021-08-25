using UnityEngine;

namespace SelectingTask
{
    public class CellCleaner : MonoBehaviour
    {
        private CellMaker _cellMaker;

        public void SetCellMaker(CellMaker cellMaker)
        {
            _cellMaker = cellMaker;
        }
        
        public void RemoveAllCells()
        {
            var cells = GetComponentsInChildren<Cell>();

            foreach (var cell in cells)
            {
                Destroy(cell.gameObject);
            }
            
            _cellMaker.TaskLabel.text = string.Empty;
        }
    }
}