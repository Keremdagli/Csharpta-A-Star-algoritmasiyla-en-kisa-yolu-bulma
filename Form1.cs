using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace yapay_zeka_final
{
    public partial class Form1 : Form
    {
        private int gridSizeX;
        private int gridSizeY;
        private Node[,] grid;
        private Node startNode, endNode;
        private List<Node> obstacles = new List<Node>();
        private bool isStartPlaced = false;
        private bool isEndPlaced = false;
        private Label[,] cells;
        private bool isPlacingStart = false;
        private bool isPlacingEnd = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string[] dimensions = txtGridSize.Text.Split(' ');
            if (dimensions.Length == 2 &&
                int.TryParse(dimensions[0], out int newGridSizeX) &&
                int.TryParse(dimensions[1], out int newGridSizeY))
            {
                if (newGridSizeX == gridSizeX && newGridSizeY == gridSizeY)
                {
                    return;
                }

                gridSizeX = newGridSizeX;
                gridSizeY = newGridSizeY;
                InitializeGrid();
                DrawGrid();
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "Geçersiz boyut.";
            }
        }

        private void InitializeGrid()
        {
            grid = new Node[gridSizeX, gridSizeY];
            cells = new Label[gridSizeX, gridSizeY];
            panelGrid.Controls.Clear();
            panelGrid.RowStyles.Clear();
            panelGrid.ColumnStyles.Clear();
            panelGrid.ColumnCount = gridSizeX;
            panelGrid.RowCount = gridSizeY;

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    grid[x, y] = new Node { X = x, Y = y, IsObstacle = false };
                    cells[x, y] = new Label
                    {
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(0),
                        Width = panelGrid.Width / gridSizeX,
                        Height = panelGrid.Height / gridSizeY,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    int cellX = x;
                    int cellY = y;
                    cells[x, y].Click += (s, e) => CellClicked(cellX, cellY);
                }
            }
        }

        private void DrawGrid()
        {
            panelGrid.ColumnCount = gridSizeX;
            panelGrid.RowCount = gridSizeY;
            panelGrid.ColumnStyles.Clear();
            panelGrid.RowStyles.Clear();

            for (int i = 0; i < gridSizeX; i++)
            {
                panelGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / gridSizeX));
            }

            for (int i = 0; i < gridSizeY; i++)
            {
                panelGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / gridSizeY));
            }

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    panelGrid.Controls.Add(cells[x, y], x, y);
                }
            }
        }

        private void btnPlaceStart_Click(object sender, EventArgs e)
        {
            isPlacingStart = true;
            isPlacingEnd = false;
        }

        private void btnPlaceEnd_Click(object sender, EventArgs e)
        {
            isPlacingStart = false;
            isPlacingEnd = true;
        }

        private void CellClicked(int x, int y)
        {
            // Eski gri ve sarı yolları temizle
            for (int i = 0; i < gridSizeX; i++)
            {
                for (int j = 0; j < gridSizeY; j++)
                {
                    if (cells[i, j].BackColor == Color.Gray || cells[i, j].BackColor == Color.Red)
                    {
                        // Başlangıç ve bitiş noktalarını koru
                        if (grid[i, j] != startNode && grid[i, j] != endNode)
                        {
                            cells[i, j].BackColor = Color.White;
                        }
                    }
                }
            }

            if (isPlacingStart)
            {
                if (startNode != null)
                {
                    cells[startNode.X, startNode.Y].BackColor = Color.White;
                }

                startNode = grid[x, y];
                cells[x, y].BackColor = Color.Yellow;
                isStartPlaced = true;
                isPlacingStart = false;
            }
            else if (isPlacingEnd)
            {
                if (endNode != null)
                {
                    cells[endNode.X, endNode.Y].BackColor = Color.White;
                }

                endNode = grid[x, y];
                cells[x, y].BackColor = Color.SkyBlue;
                isEndPlaced = true;
                isPlacingEnd = false;
            }
            else
            {
                if (grid[x, y].IsObstacle)
                {
                    grid[x, y].IsObstacle = false;
                    cells[x, y].BackColor = Color.White;
                }
                else
                {
                    if (startNode == grid[x, y] || endNode == grid[x, y])
                    {
                        lblError.Text = "Başlangıç veya bitiş noktası üzerinde engel oluşturulamaz.";
                    }
                    else
                    {
                        grid[x, y].IsObstacle = true;
                        cells[x, y].BackColor = Color.Black;
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            bool hasPath = false;
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (cells[x, y].BackColor == Color.Gray || cells[x, y].BackColor == Color.Red)
                    {
                        hasPath = true;
                        break;
                    }
                }
                if (hasPath) break;
            }

            if (hasPath)
            {
                // Sadece gri yolları ve kırmızı çözüm yolunu temizle
                for (int x = 0; x < gridSizeX; x++)
                {
                    for (int y = 0; y < gridSizeY; y++)
                    {
                        if (cells[x, y].BackColor == Color.Gray || cells[x, y].BackColor == Color.Red)
                        {
                            // Başlangıç ve bitiş noktalarını koru
                            if (grid[x, y] != startNode && grid[x, y] != endNode)
                            {
                                cells[x, y].BackColor = Color.White;
                            }
                        }
                    }
                }
            }
            else
            {
                // Her şeyi temizle
                InitializeGrid();
                DrawGrid();
                startNode = null;
                endNode = null;
                isStartPlaced = false;
                isEndPlaced = false;
            }
        }

        private async void btnFindPath_Click(object sender, EventArgs e)
        {
            if (!isStartPlaced || !isEndPlaced)
            {
                lblError.Text = "Başlangıç ve bitiş noktalarını yerleştiriniz.";
                return;
            }

            // Eski gri ve sarı yolları temizle
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (cells[x, y].BackColor == Color.Gray || cells[x, y].BackColor == Color.Red)
                    {
                        // Başlangıç ve bitiş noktalarını koru
                        if (grid[x, y] != startNode && grid[x, y] != endNode)
                        {
                            cells[x, y].BackColor = Color.White;
                        }
                    }
                }
            }

            List<Node> path = await FindPath();

            if (path != null)
            {
                foreach (Node node in path)
                {
                    if (node != startNode && node != endNode)
                    {
                        cells[node.X, node.Y].BackColor = Color.Red;
                    }
                }
                lblError.Text = "Yol bulundu.";
            }
            else
            {
                lblError.Text = "Yol bulunamadı.";
            }
        }

        private async Task<List<Node>> FindPath()
        {
            HashSet<Node> openSet = new HashSet<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = null;

                foreach (var node in openSet)
                {
                    if (currentNode == null || node.F < currentNode.F)
                    {
                        currentNode = node;
                    }
                }

                if (currentNode == endNode)
                {
                    List<Node> path = new List<Node>();
                    while (currentNode != startNode)
                    {
                        path.Add(currentNode);
                        currentNode = currentNode.Parent;
                    }
                    path.Reverse();
                    return path;
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode != startNode && currentNode != endNode)
                {
                    cells[currentNode.X, currentNode.Y].BackColor = Color.Gray;
                    await Task.Delay(100);
                }

                foreach (Node neighbor in GetNeighbors(currentNode))
                {
                    if (neighbor.IsObstacle || closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    int tentativeG = currentNode.G + GetDistance(currentNode, neighbor);

                    if (tentativeG < neighbor.G || !openSet.Contains(neighbor))
                    {
                        neighbor.G = tentativeG;
                        neighbor.H = GetDistance(neighbor, endNode);
                        neighbor.Parent = currentNode;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }

            return null;
        }

        private List<Node> GetNeighbors(Node node)
        {
            List<Node> neighbors = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    int checkX = node.X + x;
                    int checkY = node.Y + y;

                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbors.Add(grid[checkX, checkY]);
                    }
                }
            }

            return neighbors;
        }

        private int GetDistance(Node a, Node b)
        {
            int dstX = Math.Abs(a.X - b.X);
            int dstY = Math.Abs(a.Y - b.Y);

            if (dstX > dstY)
            {
                return 14 * dstY + 10 * (dstX - dstY);
            }
            return 14 * dstX + 10 * (dstY - dstX);
        }
    }

    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsObstacle { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F { get { return G + H; } }
        public Node Parent { get; set; }
    }
}