using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        int storedNumber = 0;
        string currentOperator = "";
        bool isNewInput = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        // ==========================================
        // ⭐ 새로 추가된 도우미 함수: 현재 입력 중인 숫자만 textBox2에 띄우기
        // ==========================================
        private void ShowCurrentNumber()
        {
            if (currentOperator == "")
            {
                // 아직 기호를 안 눌렀다면 첫 번째 숫자를 입력 중인 상태!
                if (!textBox1.Text.Contains("=")) // 결과 화면이 아닐 때만
                {
                    textBox2.Text = textBox1.Text;
                }
            }
            else
            {
                // 기호를 눌렀다면 두 번째 숫자를 입력 중인 상태! (기호 뒷부분만 잘라서 보여줍니다)
                int opIndex = textBox1.Text.LastIndexOf(currentOperator);
                if (opIndex != -1)
                {
                    string secondStr = textBox1.Text.Substring(opIndex + 1).Trim();
                    textBox2.Text = secondStr == "" ? "0" : secondStr;
                }
            }
        }

        // ==========================================
        // 🔢 숫자 버튼들 (0 ~ 9)
        // ==========================================
        private void button18_Click(object sender, EventArgs e) // 0
        {
            if (textBox1.Text == "0") textBox1.Text = "0";
            else textBox1.Text = textBox1.Text + "0";
            ShowCurrentNumber(); // 👈 매번 숫자를 누를 때마다 아래 칸을 업데이트!
        }

        private void button13_Click(object sender, EventArgs e) // 1
        {
            if (textBox1.Text == "0") textBox1.Text = "1";
            else textBox1.Text = textBox1.Text + "1";
            ShowCurrentNumber();
        }

        private void button14_Click(object sender, EventArgs e) // 2
        {
            if (textBox1.Text == "0") textBox1.Text = "2";
            else textBox1.Text = textBox1.Text + "2";
            ShowCurrentNumber();
        }

        private void button15_Click(object sender, EventArgs e) // 3
        {
            if (textBox1.Text == "0") textBox1.Text = "3";
            else textBox1.Text = textBox1.Text + "3";
            ShowCurrentNumber();
        }

        private void button9_Click(object sender, EventArgs e) // 4
        {
            if (textBox1.Text == "0") textBox1.Text = "4";
            else textBox1.Text = textBox1.Text + "4";
            ShowCurrentNumber();
        }

        private void button10_Click(object sender, EventArgs e) // 5
        {
            if (textBox1.Text == "0") textBox1.Text = "5";
            else textBox1.Text = textBox1.Text + "5";
            ShowCurrentNumber();
        }

        private void button11_Click(object sender, EventArgs e) // 6
        {
            if (textBox1.Text == "0") textBox1.Text = "6";
            else textBox1.Text = textBox1.Text + "6";
            ShowCurrentNumber();
        }

        private void button5_Click(object sender, EventArgs e) // 7
        {
            if (textBox1.Text == "0") textBox1.Text = "7";
            else textBox1.Text = textBox1.Text + "7";
            ShowCurrentNumber();
        }

        private void button6_Click(object sender, EventArgs e) // 8
        {
            if (textBox1.Text == "0") textBox1.Text = "8";
            else textBox1.Text = textBox1.Text + "8";
            ShowCurrentNumber();
        }

        private void button7_Click(object sender, EventArgs e) // 9
        {
            if (textBox1.Text == "0") textBox1.Text = "9";
            else textBox1.Text = textBox1.Text + "9";
            ShowCurrentNumber();
        }

        // ==========================================
        // ➕➖✖➗ 연산자 버튼들
        // ==========================================
        private void button16_Click(object sender, EventArgs e) // 더하기(+)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Contains("=")) textBox1.Text = textBox2.Text; // 결과(7)에서 이어서 계산하기 방어막
                storedNumber = int.Parse(textBox1.Text);
                currentOperator = "+";
                textBox1.Text = storedNumber.ToString() + " + ";
            }
        }

        private void button12_Click(object sender, EventArgs e) // 빼기(-)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Contains("=")) textBox1.Text = textBox2.Text;
                storedNumber = int.Parse(textBox1.Text);
                currentOperator = "-";
                textBox1.Text = storedNumber.ToString() + " - ";
            }
        }

        private void button8_Click(object sender, EventArgs e) // 곱하기(*)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Contains("=")) textBox1.Text = textBox2.Text;
                storedNumber = int.Parse(textBox1.Text);
                currentOperator = "*";
                textBox1.Text = storedNumber.ToString() + " * ";
            }
        }

        private void button4_Click(object sender, EventArgs e) // 나누기(/)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Contains("=")) textBox1.Text = textBox2.Text;
                storedNumber = int.Parse(textBox1.Text);
                currentOperator = "/";
                textBox1.Text = storedNumber.ToString() + " / ";
            }
        }

        // ==========================================
        // 🟰 결과보기 및 지우기 버튼들
        // ==========================================
        private void button20_Click(object sender, EventArgs e) // 결과보기(=)
        {
            if (currentOperator == "" || textBox1.Text == "" || textBox1.Text.Contains("=")) return;

            int opIndex = textBox1.Text.LastIndexOf(currentOperator);
            if (opIndex == -1) return;

            string secondStr = textBox1.Text.Substring(opIndex + 1).Trim();
            if (secondStr == "") secondStr = "0";

            int secondNumber = int.Parse(secondStr);
            int result = 0;

            if (currentOperator == "+") result = storedNumber + secondNumber;
            else if (currentOperator == "-") result = storedNumber - secondNumber;
            else if (currentOperator == "*") result = storedNumber * secondNumber;
            else if (currentOperator == "/")
            {
                if (secondNumber != 0) result = storedNumber / secondNumber;
                else { textBox2.Text = "0으로 나눌 수 없습니다."; return; }
            }

            // 계산이 끝나면 연산자를 비워줍니다 (다음 계산을 위해)
            currentOperator = "";
            textBox1.Text = storedNumber.ToString() + " " + currentOperator + " " + secondNumber.ToString() + " = " + result.ToString();
            textBox2.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e) // C 버튼
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            storedNumber = 0;
            currentOperator = "";
        }

        private void button1_Click(object sender, EventArgs e) // CE 버튼
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            ShowCurrentNumber(); // CE로 지운 후에도 아랫칸을 0으로 동기화
        }

        private void button3_Click(object sender, EventArgs e) // Del 버튼
        {
            if (textBox1.Text != "0" && textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                if (textBox1.Text == "") textBox1.Text = "0";
                ShowCurrentNumber(); // 👈 한 글자 지울 때마다 아랫칸도 업데이트!
            }
        }
    }
}