using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ski_jumping_points_calculator {
    public partial class Form1 : Form  {
        Jumper jumper; Hill hill; Jump jump; RandomGenerator random; 
        public Form1() { InitializeComponent(); }
        private void Form1_Load(object sender, EventArgs e) {
            jumper = new Jumper(); txtJumperName.Text = jumper.getFakeFullName();
            hill = new Hill(); jump = new Jump();
            if (!hill.downloadHills()){ Console.WriteLine("The hills from json files were not able to get downloaded!");}
            random = new RandomGenerator();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (txtJumperName.Text.Length < 3) {
                txtJumperName.Focus();
                MessageBox.Show("Please provide input for jumper's name!","Input data missing",MessageBoxButtons.OK,MessageBoxIcon.Error);return;
            } else if (txtHillName.Text.Length < 3) {
                txtHillName.Focus();
                MessageBox.Show("Please provide input for hill name!", "Input data missing",MessageBoxButtons.OK,MessageBoxIcon.Error);return;
            } else if (txtKPoint.Text.Length < 3) {
                txtKPoint.Focus();
                MessageBox.Show("Please provide input for hill's k-point!", "Input data missing",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            } else {
                jumper.setJumper(txtJumperName.Text); //in case jumper's name changed & fake name not used                
                random.setSuccessLevel(); //instead of using user provided info for jump, styles, etc. random generator is used to determine how successful the jump has been
                int sLevel = random.getSuccessLevel();
                int hillDist = hill.getKPointDistance();
                int splitIntoHalf = random.getSplitIntoHalf();
                jump.setJumpDistance(sLevel, splitIntoHalf,hillDist);
                jump.setPlatformLevel(lblPlatformLevel.Text, hill.getKPointDistancePointsPerMeter());
                jump.setWindCompensation(hill.getKPointDistance(), hill.getKPointDistancePointsPerMeter());
                displayResults();                    
            }
        }

        //display results
        private void displayResults() {
            lblJumperName.Text = txtJumperName.Text;
            lblHillName.Text = txtHillName.Text;
            lblKPoint.Text = hill.getKPointDistance().ToString();
            lblJumpLength.Text = jump.getJumpDistance().ToString();

            //points for the jump
            float pointsForJump = jump.calculatePointsForJump(hill.getKPointDistance(), hill.getKPointDistancePointsPerMeter());
            lblJumpPoints.Text = Math.Round(pointsForJump, 2).ToString();

            //style for jump
            jump.handleStyles(random);
            Tuple<string,string,float> t = jump.getStylePoints();
            float pointsForStyle = t.Item3;
            lblStylesPoints.Text = t.Item3.ToString();
            lblStylesPointsWith.Text = t.Item2;
            lblStylesPointsWithout.Text = t.Item1;

            //platform compensation
            float pointsForPlatform = jump.getPlatformCompensationPoints();
            lblPlatformCompensation.Text = Math.Round(pointsForPlatform, 2).ToString();

            //wind compensation
            double pointsForWind = jump.getWindCompensation();
            lblWindCompensation.Text = Math.Round(pointsForWind, 2).ToString();

            //calculate total points
            lblTotalPoints.Text = Math.Round((pointsForJump + pointsForStyle + pointsForPlatform + pointsForWind),2).ToString();
        }

        private void testEnterDown(object sender, KeyEventArgs e) {
            if (txtHillName.Text == "") {
                txtKPoint.Text = "";
                return;
            } else if (e.KeyCode == Keys.Enter) {
                txtKPoint.Text = hill.getKPoint(txtHillName.Text);
                int kpoint;
                if (!int.TryParse(txtKPoint.Text, out kpoint))  {
                    txtKPoint.Text = "";
                    return;
                }
                hill.setKPoint(kpoint);
                hill.setKPointDistancePointsPerMeter();
                txtKPoint.Focus();
            }
        }

        private void acceptNumber(object sender, KeyEventArgs e)  {
            if (txtKPoint.Text == "") {
                txtKPoint.Text = "";
                txtKPoint.Focus();
                return;
            } else if (e.KeyCode == Keys.Enter)  {
                int kpoint;
                if (!int.TryParse(txtKPoint.Text, out kpoint))  {
                    txtKPoint.Text = "";
                    txtKPoint.Focus();
                    return;
                }
                if (kpoint >= 20 && kpoint <= 225)  {
                    hill.setKPoint(kpoint);
                    hill.setKPointDistancePointsPerMeter();
                    txtKPoint.Text = kpoint.ToString();
                    tBarEntryLevel.Focus();
                } else {
                    txtKPoint.Text = "";
                    txtKPoint.Focus();
                    return;
                }
            }
        }

        private void tBarEntryLevel_Scroll(object sender, EventArgs e) {
            if (tBarEntryLevel.Value.ToString() == "1") {
                lblPlatformLevel.Text = "-2,8";
            }
            if (tBarEntryLevel.Value.ToString() == "2") {
                lblPlatformLevel.Text = "-1,4";
            }
            if (tBarEntryLevel.Value.ToString() == "3") {
                lblPlatformLevel.Text = "0";
            }
            if (tBarEntryLevel.Value.ToString() == "4") {
                lblPlatformLevel.Text = "1,4";
            }
            if (tBarEntryLevel.Value.ToString() == "5") {
                lblPlatformLevel.Text = "2,8";
            }
            jump.setPlatform(lblPlatformLevel.Text);
            jump.calculatePlatformMeters();
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }
        private void label19_Click(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void label5_Click_1(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void txtHillName_TextChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) {}
    }
}
