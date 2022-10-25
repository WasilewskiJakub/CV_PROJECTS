using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor
{
    public partial class Form1 : Form
    {

        
        private Bitmap drawArea;

        public Form1()
        {
            Property.Style = EdgeStyle.SystemLine;
            Property.LineWidth = 3;
            Property.polygons = new PolygonSet();
            Property.curr_color = Color.Black;
            Property.len_counter = 1;
            Property.perps_list = new List<Perpendicular>();
            InitializeComponent();
            Bresen.Enabled = false;
            Sysline.Enabled = false;
            this.Icon = Properties.Resources.LOGO;
            EditFLags(false);
            drawArea = new Bitmap(Canvas.Size.Width, Canvas.Size.Height);
            Canvas.Image = drawArea;
            SetColorPreview(Property.curr_color);
            Property.Tolerance = 2;
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
            }
            MakeTemporaryPolygons();
            PaintAllPolygons();
            Canvas.Refresh();
        }
        private void SetColorPreview(Color C)
        {
            ColorLabel.BackColor = C;
        }
        private void TakeColorFromDialog()
        {
            ColorDialog dl = new ColorDialog();
            if (dl.ShowDialog() == DialogResult.OK)
            {
                Property.curr_color = dl.Color;
            }
            SetColorPreview(Property.curr_color);
        }
        private void ColorButt_Click(object sender, EventArgs e)
        {
            TakeColorFromDialog();
        }

        private void ColorLabel_Click(object sender, EventArgs e)
        {
            TakeColorFromDialog();
        }

        private void MakeTemporaryPolygons()
        {
            Polygon pol1 = new Polygon();
            pol1.AddVertex(new Polygon.Vertex(100, 100, null));
            pol1.AddVertex(new Polygon.Vertex(100, 300, null));
            pol1.AddVertex(new Polygon.Vertex(400, 300, null));
            pol1.AddVertex(new Polygon.Vertex(400, 100, null));
            FinishPolygon(pol1);
            if (!pol1.IsClockwise())
                pol1.MakeClockwise();
            int iter = 0;
            foreach(var ed in pol1.edges.Values)
            {
                if(iter<3)
                {
                    ed.CalcLength();
                    ed.number_length = Property.len_counter++;
                    ed.color = Color.Red;
                    iter++;
                }
            }
            Property.polygons.Polygons.Add(pol1);
            Polygon pol2 = new Polygon();
            pol2.AddVertex(new Polygon.Vertex(120, 400, null));
            pol2.AddVertex(new Polygon.Vertex(160, 470, null));
            pol2.AddVertex(new Polygon.Vertex(110, 530, null));
            pol2.AddVertex(new Polygon.Vertex(300, 600, null));
            pol2.AddVertex(new Polygon.Vertex(700, 610, null));
            pol2.AddVertex(new Polygon.Vertex(720, 440, null));
            pol2.AddVertex(new Polygon.Vertex(400, 390, null));
            FinishPolygon(pol2);
            if (!pol2.IsClockwise())
                pol2.MakeClockwise();

            Property.polygons.Polygons.Add(pol2);
            var perpe = new Perpendicular(pol2.edges[(pol2.list[1],pol2.list[2])], pol2.edges[(pol2.list[2], pol2.list[3])]);
            pol2.edges[(pol2.list[1], pol2.list[2])].perpe = perpe;
            pol2.edges[(pol2.list[2], pol2.list[3])].perpe = perpe;
            pol2.edges[(pol2.list[1], pol2.list[2])].color = Color.Blue;
            pol2.edges[(pol2.list[2], pol2.list[3])].color = Color.Blue;

            pol2.edges[(pol2.list[0], pol2.list[1])].CalcLength();
            pol2.edges[(pol2.list[0], pol2.list[1])].number_length = Property.len_counter++;
            pol2.edges[(pol2.list[0], pol2.list[1])].color = Color.Red;

            pol2.edges[(pol2.list[6], pol2.list[0])].CalcLength();
            pol2.edges[(pol2.list[6], pol2.list[0])].number_length = Property.len_counter++;
            pol2.edges[(pol2.list[6], pol2.list[0])].color = Color.Red;

            pol2.edges[(pol2.list[5], pol2.list[6])].CalcLength();
            pol2.edges[(pol2.list[5], pol2.list[6])].number_length = Property.len_counter++;
            pol2.edges[(pol2.list[5], pol2.list[6])].color = Color.Red;


            Property.workingpolyg = pol2;
            perpe.MakePerpendicular();
            Property.perps_list.Add(perpe);
            Property.ResetProperty();

        }

        private void AddVertex(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CreateAction.Checked)
            {
                CountPolyg.Text = $"{Property.polygons.Polygons.Count}";
                var newVert = new Polygon.Vertex(e.X, e.Y, null);
                Polygon curr = Property.polygons.GetCurrent();
                if(curr.list.Count!=0 && curr.list[0].Equals(newVert))
                {
                    FinishPolygon(Property.polygons.GetCurrent());
                    Canvas.Refresh();
                    return;
                }
                foreach (var polys in Property.polygons.Polygons)
                {
                    if (polys.list.Exists((x) => x.Equals(newVert)))
                    {
                        return;
                    }       
                }
                if (!curr.AddVertex(newVert))
                    newVert.PaintVertex(ref drawArea);
                else
                    EdgeMaker.DrawSegment(ref drawArea, curr.edges[(newVert.prev, newVert)]);
                Canvas.Refresh();
            }
            else if(e.Button == MouseButtons.Left && EditAction.Checked)
            {
                
                foreach (var v in Property.polygons.Polygons)
                {
                    Property.ResetProperty();
                    if (v.list.Exists((x) => x.Equals(new Polygon.Vertex(e.X, e.Y, null))))
                    {
                        EdgeFlags(false);
                        VertFlags(false);
                        var t = v.list.Find((x) => x.Equals(new Polygon.Vertex(e.X, e.Y, null)));
                        if(Selpolyg.Checked)
                        {
                            if (Property.workingpolyg != null)
                            {
                                Property.workingpolyg.Select(false);
                            }
                            Property.workingpolyg = v;
                            Property.verts_cp = v.list.Copy();
                            RemovePoly.Enabled = true;
                            v.Select(true);
                        }
                        else
                        {
                            Property.selected_edge = null;
                            Property.selected = t;
                            Property.workingpolyg = v;
                            if (AllRelations(v))
                            {
                                Property.verts_cp = v.list.Copy();
                                //Property.movepolyg = true;
                            }
                            VertFlags(true);
                        }
                        PaintAllPolygons(true);
                        PaintAllPolygons(false);
                        Canvas.Refresh();
                        return;
                    }
                }
                Property.selected = null;
                // EDGE SELECT:
                foreach(var v in Property.polygons.Polygons)
                {
                    foreach(var ed in v.edges.Values)
                    {
                        if(ed.IsSelected((e.X,e.Y)))
                        {
                            EdgeFlags(false);
                            VertFlags(false);
                            Property.ResetProperty();
                            if (Selpolyg.Checked)
                            {
                                if(Property.workingpolyg != null)
                                {
                                    Property.workingpolyg.Select(false);
                                }
                                Property.workingpolyg = v;
                                RemovePoly.Enabled = true;
                                Property.verts_cp = v.list.Copy();
                                v.Select(true);
                            }
                            else
                            {
                                Property.workingpolyg = v;
                                Property.selected_edge = ed;
                                if(AllRelations(v))
                                {
                                    Property.verts_cp = v.list.Copy();
                                    //Property.movepolyg = true;
                                }
                                EdgeFlags(true);
                            }
                            PaintAllPolygons(true);
                            PaintAllPolygons(false);
                            Canvas.Refresh();
                            return;
                        }
                    }
                }
                if(Property.workingpolyg!=null)
                {
                    Property.workingpolyg.Select(false);
                    Property.verts_cp = null;
                }
                if (Property.toperpe != null)
                    Property.toperpe.color = Color.Black;
                Property.toperpe = null;
                Property.ResetProperty();
                VertFlags(false);
                EdgeFlags(false);
                PaintAllPolygons(true);
                PaintAllPolygons(false);
                Canvas.Refresh();
            }
            else if(e.Button == MouseButtons.Middle && Property.verts_cp != null)
            {
                Property.movevert = false;
                Property.moveedge = false;
                Property.movepolyg = true;
                Property.curr_cur = new CursorPos(e.X, e.Y);
                Property.verts_cp = Property.workingpolyg.list.Copy();
            }
            else if(e.Button == MouseButtons.Middle && Property.selected!=null)
            {
                Property.moveedge = false;
                Property.movepolyg = false;

                Property.movevert = true;

                Property.curr_cur = new CursorPos(e.X, e.Y);
                Property.VertCopy = new Polygon.Vertex(Property.selected);
            }
            else if (e.Button == MouseButtons.Middle && Property.selected_edge != null)
            {
                Property.movevert = false;
                Property.movepolyg = false;
                Property.moveedge = true;
                Property.curr_cur = new CursorPos(e.X, e.Y);
                Property.edge_copy = new Edge(Property.selected_edge);
            }
        }
        private bool AllRelations(Polygon pol)
        {
            int counter = 0;
            foreach (var e in pol.edges.Values)
                if (e.perpe != null || e.length != 0)
                    counter++;
            return counter == pol.list.Count;
        }
        private void ChangeVertPosition(Polygon p, Polygon.Vertex v, ref Bitmap BtM, MouseEventArgs e)
        {
            p.PaintPolygon(ref BtM, true);
            v.X = e.X;
            v.Y = e.Y;
            p.PaintPolygon(ref BtM, false);
        }
        private void ChooseEdit(object sender, EventArgs e)
        {
            PolyFlags(true);
            Bresen.Enabled = true;
            Sysline.Enabled = true;
            Polygon curr = Property.polygons.GetCurrent();
            if (curr.list.Count<3)
            {
                if(curr.list.Count>0)
                {
                    MessageBox.Show("Can' t create Polygon with less than 3 vertex");
                    curr.PaintPolygon(ref drawArea, true);
                    
                }   
                Property.polygons.Polygons.RemoveAt(Property.polygons.Polygons.Count - 1);
                PaintAllPolygons();
                Canvas.Refresh();
            }
            else
                FinishPolygon(curr);
        }

        private void FinishPolygon(Polygon curr)
        {
            if (curr.list.Count == 0)
                return;
            curr.list[0].prev = curr.list[curr.list.Count - 1];
            curr.list[curr.list.Count - 1].next = curr.list[0];
            curr.edges.Add((curr.list[curr.list.Count - 1], curr.list[0]), new Edge(curr.list[curr.list.Count - 1], curr.list[0]));
            EdgeMaker.DrawSegment(ref drawArea, curr.edges[(curr.list[curr.list.Count - 1], curr.list[0])]);
            if (!curr.IsClockwise())
                curr.MakeClockwise();
            Canvas.Refresh();
        }

        private void DisabelMoving(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                Property.movevert = false;
                Property.moveedge = false;
                if(Property.movepolyg)
                {
                    Property.movepolyg = false;
                }
            }
        }
        private void Moving(object sender, MouseEventArgs e)
        {
            if(Property.movepolyg)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.Clear(Color.White);
                    for(int i = 0; i <Property.verts_cp.Count;i++)
                    {
                        Property.workingpolyg.list[i].X = Property.verts_cp[i].X + e.X - Property.curr_cur.X;
                        Property.workingpolyg.list[i].Y = Property.verts_cp[i].Y + e.Y - Property.curr_cur.Y;
                    }
                    PaintAllPolygons();
                }
                Canvas.Refresh();
                return;
            }
            if(Property.movevert)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.Clear(Color.White);
                    Polygon.Vertex node = new Polygon.Vertex(Property.selected);
                    //LengthRelation tmp = new LengthRelation(Property.selected,null);
                    Property.selected.X = Property.VertCopy.X + e.X - Property.curr_cur.X;
                    Property.selected.Y = Property.VertCopy.Y + e.Y - Property.curr_cur.Y;
                    LengthRelation len = new LengthRelation(Property.selected, node);
                    len.MoveEdges();
                    PaintAllPolygons();
                    string tmp = "";
                    foreach (var e1 in Property.workingpolyg.edges.Values)
                    {
                        if (e1.length!=0)
                            tmp += $"{e1.number_length} Length: {e1.length}\n";
                    }
                    Info.Text = tmp;
                }
                Canvas.Refresh();
                return;
            }
            if(Property.moveedge)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.Clear(Color.White);
                    var edge_clone = new Edge(Property.selected_edge);
                    Property.selected_edge.v1.X = Property.edge_copy.v1.X + e.X - Property.curr_cur.X;
                    Property.selected_edge.v1.Y = Property.edge_copy.v1.Y + e.Y - Property.curr_cur.Y;
                    Property.selected_edge.v2.X = Property.edge_copy.v2.X + e.X - Property.curr_cur.X;
                    Property.selected_edge.v2.Y = Property.edge_copy.v2.Y + e.Y - Property.curr_cur.Y;
                    LengthRelation len = new LengthRelation(Property.selected_edge,edge_clone);
                    len.MoveEdges();
                    PaintAllPolygons();
                    string tmp = "";
                    foreach (var e1 in Property.workingpolyg.edges.Values)
                    {
                        if (e1.length != 0)
                            tmp += $"{e1.number_length} Length: {e1.length}\n";
                    }
                    Info.Text = tmp;
                }
                Canvas.Refresh();
                return;
            }
        }
        private void PaintAllPolygons(bool hide = false)
        {
            if (hide == true)
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.Clear(Color.White);
                    return;
                }
            foreach (var p in Property.polygons.Polygons)
            {
                p.PaintPolygon(ref drawArea,hide);
            }
        }

        private void RemoveVert_Click(object sender, EventArgs e)
        {

            if(Property.selected != null)
            {
                if(Property.workingpolyg.list.Count - 1 < 3)
                {
                    MessageBox.Show("Can not remove vertex, min quant is 3");
                    return;
                }
                (Property.selected.prev.next, Property.selected.next.prev) = (Property.selected.next, Property.selected.prev);
                Property.workingpolyg.list.Remove(Property.selected);
                Property.workingpolyg.HashSet.Remove((Property.selected.X, Property.selected.Y));
                var ed = Property.workingpolyg.edges[(Property.selected, Property.selected.next)];
                if (ed.perpe != null)
                {
                    Property.perps_list.RemoveAt(Property.perps_list.IndexOf(ed.perpe));
                    (ed.perpe.e1.color, ed.perpe.e2.color) = (Color.Black, Color.Black);
                    (ed.perpe.e1.perpe, ed.perpe.e2.perpe) = (null, null);
                }
                Property.workingpolyg.edges.Remove((Property.selected, Property.selected.next));

                ed = Property.workingpolyg.edges[(Property.selected.prev, Property.selected)];
                if (ed.perpe != null)
                {
                    Property.perps_list.RemoveAt(Property.perps_list.IndexOf(ed.perpe));
                    (ed.perpe.e1.color, ed.perpe.e2.color) = (Color.Black, Color.Black);
                    (ed.perpe.e1.perpe, ed.perpe.e2.perpe) = (null, null);
                }
                Property.workingpolyg.edges.Remove((Property.selected.prev,Property.selected));

                Property.workingpolyg.edges.Add((Property.selected.prev, Property.selected.next), new Edge(Property.selected.prev, Property.selected.next));
                PaintAllPolygons(true);
                PaintAllPolygons();
                Canvas.Refresh();
                Property.selected = null;
            }
        }

        private void ColorVert_Click(object sender, EventArgs e)
        {
            if(Property.selected != null)
            {
                Property.selected.color = Property.curr_color;
                Property.selected.PaintVertex(ref drawArea);
                Canvas.Refresh();
            }
        }
        private void ChoseCreate(object sender, EventArgs e)
        {
            EditFLags(false);
            Property.selected = null;
            Property.ResetProperty();
            Bresen.Enabled = false;
            Sysline.Enabled = false;
            if (Property.toperpe != null)
            {
                Property.toperpe.color = Color.Black;
                EdgeMaker.DrawSegment(ref drawArea, Property.toperpe);
                Property.toperpe = null;
                Canvas.Refresh();
            }
            if (Property.workingpolyg != null)
            {
                Property.workingpolyg.Select(false);
                Property.workingpolyg.PaintPolygon(ref drawArea);
            }
            Canvas.Refresh();
            Selpolyg.Enabled = false;
        }

        private void RemoveEdge(object sender, EventArgs e)
        {
            if(Property.workingpolyg.list.Count - 2 < 3)
            {
                MessageBox.Show("Can not remove vertex, min quant is 3");
                return;
            }
            if(Property.selected_edge != null)
            {
                var tmp = Property.selected_edge;
                (tmp.v1.prev.next, tmp.v2.next.prev) = (tmp.v2.next, tmp.v1.prev);
                Property.workingpolyg.list.Remove(tmp.v1);
                Property.workingpolyg.list.Remove(tmp.v2);

                var ed = Property.workingpolyg.edges[(tmp.v1, tmp.v2)];
                if (ed.perpe != null)
                {
                    Property.perps_list.RemoveAt(Property.perps_list.IndexOf(ed.perpe));
                    (ed.perpe.e1.color, ed.perpe.e2.color) = (Color.Black, Color.Black);
                    (ed.perpe.e1.perpe, ed.perpe.e2.perpe) = (null, null);
                }
                Property.workingpolyg.edges.Remove((tmp.v1, tmp.v2));

                ed = Property.workingpolyg.edges[(tmp.v1.prev, tmp.v1)];
                if (ed.perpe != null)
                {
                    Property.perps_list.RemoveAt(Property.perps_list.IndexOf(ed.perpe));
                    (ed.perpe.e1.color, ed.perpe.e2.color) = (Color.Black, Color.Black);
                    (ed.perpe.e1.perpe, ed.perpe.e2.perpe) = (null, null);
                }
                
                Property.workingpolyg.edges.Remove((tmp.v1.prev, tmp.v1));

                ed = Property.workingpolyg.edges[(tmp.v2, tmp.v2.next)];
                if (ed.perpe != null)
                {
                    Property.perps_list.RemoveAt(Property.perps_list.IndexOf(ed.perpe));
                    (ed.perpe.e1.color, ed.perpe.e2.color) = (Color.Black, Color.Black);
                    (ed.perpe.e1.perpe, ed.perpe.e2.perpe) = (null, null);
                }
                Property.workingpolyg.edges.Remove((tmp.v2, tmp.v2.next));

                Property.workingpolyg.HashSet.Remove((tmp.v1.X, tmp.v1.Y));
                Property.workingpolyg.HashSet.Remove((tmp.v2.X, tmp.v2.Y));
                Property.workingpolyg.edges.Add((tmp.v1.prev, tmp.v2.next), new Edge(tmp.v1.prev, tmp.v2.next));
                PaintAllPolygons(true);
                PaintAllPolygons();
                Canvas.Refresh();
                Property.selected_edge = null;
            }
        }

        private void SplitEdge(object sender, EventArgs e)
        {
            if (Property.selected_edge != null)
            {
                var tmp = Property.selected_edge;

                var ed = Property.workingpolyg.edges[(tmp.v1, tmp.v2)];
                if (ed.perpe != null)
                {
                    Property.perps_list.RemoveAt(Property.perps_list.IndexOf(ed.perpe));
                    (ed.perpe.e1.color, ed.perpe.e2.color) = (Color.Black, Color.Black);
                    (ed.perpe.e1.perpe, ed.perpe.e2.perpe) = (null, null);
                }
                Property.workingpolyg.edges.Remove((tmp.v1, tmp.v2));

                var newVert = Polygon.Vertex.getBetween(tmp.v1, tmp.v2);
                newVert.prev = tmp.v1;
                tmp.v1.next = newVert;
                tmp.v2.prev = newVert;
                newVert.next = tmp.v2;
                Property.workingpolyg.list.Insert(Property.workingpolyg.list.IndexOf(tmp.v2), newVert);
                Property.workingpolyg.HashSet.Add((newVert.X, newVert.Y), newVert);
                Property.workingpolyg.edges.Add((tmp.v1, newVert), new Edge(tmp.v1, newVert));
                Property.workingpolyg.edges.Add((newVert, tmp.v2), new Edge(newVert, tmp.v2));
                PaintAllPolygons(true);
                PaintAllPolygons();
                Canvas.Refresh();
                Property.selected_edge = null;
            }
        }
        private void SelPol_CLick(object sender, EventArgs e)
        {
            if (Property.workingpolyg != null)
            {
                Property.workingpolyg.Select(false);
                Property.verts_cp = null;
                Property.workingpolyg = null;
            }
            if (!Selpolyg.Checked)
                RemovePoly.Enabled = false;
            Property.ResetProperty();
            PaintAllPolygons(true);
            PaintAllPolygons(false);
            Canvas.Refresh();
        }
        private void EditFLags(bool show = false)
        {
            VertFlags(show);
            EdgeFlags(show);
            PolyFlags(show);
            RemovePoly.Enabled = show;
        }
        private void PolyFlags(bool show = false)
        {
            Selpolyg.Enabled = show;
        }
        private void VertFlags(bool show = false)
        {
            RemoveVert.Enabled = show;
            ColorVert.Enabled = show;
        }
        private void EdgeFlags(bool show = false)
        {
            SaveLen.Enabled = show;
            RemEdge.Enabled = show;
            Splitedge.Enabled = show;
            perpendicular.Enabled = show;
        }
        private void RemovePolygon(object sender, EventArgs e)
        {
            if(Property.workingpolyg!=null)
            {
                foreach(var ed in Property.workingpolyg.edges.Values)
                        if (ed.perpe != null)
                        {
                            Property.perps_list.RemoveAt(Property.perps_list.IndexOf(ed.perpe));
                            (ed.perpe.e1.color, ed.perpe.e2.color) = (Color.Black, Color.Black);
                            (ed.perpe.e1.perpe, ed.perpe.e2.perpe) = (null, null);
                        }

                Property.polygons.Polygons.Remove(Property.workingpolyg);
                Property.workingpolyg = null;
                Property.ResetProperty();
                RemovePoly.Enabled = false;
                PaintAllPolygons(true);
                PaintAllPolygons(false);
                Canvas.Refresh();
                CountPolyg.Text = $"{Property.polygons.Polygons.Count}";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Property.Style = EdgeStyle.Bresenham;
            PaintAllPolygons(true);
            PaintAllPolygons(false);
            Canvas.Refresh();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Property.Style = EdgeStyle.SystemLine;
            PaintAllPolygons(true);
            PaintAllPolygons(false);
            Canvas.Refresh();
        }

        private void SetLength(object sender, EventArgs e)
        {
            if(Property.selected_edge.perpe!= null)
            {
                MessageBox.Show("This Edge is Perpedincular!");
            }
            if(Property.selected_edge!=null)
            {
                if(Property.selected_edge.length!=0)
                {
                    // usuawanie Length
                    foreach (var pol in Property.polygons.Polygons)
                        foreach (var ed in pol.edges.Values)
                            if (ed.number_length > Property.selected_edge.number_length)
                                ed.number_length--;
                    Property.len_counter--;
                    Property.selected_edge.number_length = 0;
                    Property.selected_edge.length = 0;
                    Property.selected_edge.color = Color.Black;
                }
                else
                {
                    int counter = 0;
                    var tmp = Property.workingpolyg.edges.Values;
                    foreach (var edges in tmp)
                        if (edges.length != 0)
                            counter++;
                    if (counter == tmp.Count - 1)
                    {
                        MessageBox.Show("Cant set Length for all edges in polygon!");
                        return;
                    }
                    Property.selected_edge.number_length = (Property.len_counter++);
                    Property.selected_edge.CalcLength();
                    Property.selected_edge.color = Color.Red;
                }
                string tmp1 = "";
                foreach (var e1 in Property.workingpolyg.edges.Values)
                {
                    if (e1.length != 0)
                        tmp1 += $"{e1.number_length} Length: {e1.length}\n";
                }
                Info.Text = tmp1;
                PaintAllPolygons(true);
                PaintAllPolygons(false);
                Canvas.Refresh();
            }
        }

        private void MakePerpe(object sender, EventArgs e)
        {
            if(Property.selected_edge.length!=0)
            {
                MessageBox.Show("This Edge has Fixed Length");
                if (Property.toperpe != null)
                {
                    Property.toperpe.color = Color.Black;
                    EdgeMaker.DrawSegment(ref drawArea, Property.toperpe);
                    Property.toperpe = null;
                }
                Canvas.Refresh();
                return;
            }
            if(Property.selected_edge.perpe != null)
            {
                (Property.selected_edge.perpe.e1.color, Property.selected_edge.perpe.e2.color) = (Color.Black, Color.Black);
                
                EdgeMaker.DrawSegment(ref drawArea, Property.selected_edge.perpe.e1);
                EdgeMaker.DrawSegment(ref drawArea, Property.selected_edge.perpe.e2);
                Property.perps_list.RemoveAt(Property.perps_list.IndexOf(Property.selected_edge.perpe));
                (Property.selected_edge.perpe.e1.perpe, Property.selected_edge.perpe.e2.perpe) = (null, null);
                if(Property.toperpe!=null)
                {
                    Property.toperpe.color = Color.Black;
                    Property.toperpe = null;
                }
                PaintAllPolygons(true);
                PaintAllPolygons(false);
                Canvas.Refresh();
                return;
            }
            if (Property.toperpe == null)
            {
                Property.toperpe = Property.selected_edge;
                Property.toperpe.color = Color.Blue;
                EdgeMaker.DrawSegment(ref drawArea, Property.toperpe);
                Canvas.Refresh();
            }
            else
            {
                if(Property.toperpe == Property.selected_edge)
                {
                    MessageBox.Show("You choose same Edges!\nCan't make perpedincular");
                    Property.toperpe.color = Color.Black;
                    Property.toperpe = null;

                    return;
                }
                var perpe = new Perpendicular(Property.toperpe, Property.selected_edge);
                Property.toperpe.perpe = perpe;
                Property.selected_edge.perpe = perpe;
                Property.selected_edge.color = Color.Blue;
                Property.toperpe = null;
                EdgeMaker.DrawSegment(ref drawArea, Property.selected_edge);
                perpe.MakePerpendicular();
                Property.perps_list.Add(perpe);
                PaintAllPolygons(true);
                PaintAllPolygons(false);
                Canvas.Refresh();
            }
        }
    }
}
