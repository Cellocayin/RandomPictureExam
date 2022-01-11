using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 채희재_랜덤시험문제
{
    public partial class 채희재_랜덤시험문제 : Form
    {
        PictureBox[] P = new PictureBox[5];  //PictureBox배열 생성
        GroupBox[] GB = new GroupBox[5];  // GroupBox배열  생성
        RadioButton[,] Bogi = new RadioButton[5, 5];  //라디오버튼 배열 생성        
        Label lbScore = new Label();  //label 생성
        Button button = new Button();  //버튼 생성
        int Score = 0;
        public 채희재_랜덤시험문제()
        {
            InitializeComponent();
            string aa = "[문제";
            string[,] Question = new string[5, 6]
            {
                {"다음중 1+1=?","일","이","삼","사","이" },
                {"인천에 있는 산은?","한라산","백두산","계양산","금강산","계양산" },
               {"인천대학은 어느 구에 있나?","송도구","연수구","남구","중구","연수구" },
               {"다음중 아이유가 아닌 사진은?","1","2","3","4","4" },  //문제는 텍스트, 보기는 사진
                {"다음 개의 품종은?","골든리트리버","시츄","웰시코기","사모예드","골든리트리버" }, //문제는 사진, 보기는 텍스트
             };
            lbScore = new Label(); //점수표시 위한 label 동적 생성
            this.lbScore.Name = "lbScore";
            this.lbScore.Text = "Score";
            this.lbScore.Size = new Size(90, 30);
            this.lbScore.Location = new System.Drawing.Point(30, 500);
            this.Controls.Add(lbScore);

            this.button.Name = "btnSubmit";  //버튼 동적 생성
            this.button.Text = "채점하기";
            this.button.Size = new Size(90, 30);
            this.button.AutoSize = true;
            this.button.Location = new System.Drawing.Point(100, 550);
            this.button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
            int[] array1 = new int[3];  //5문제중 무작위 3문제 골라서 해당 index를 저장하기 위한 배열
            Random r = new Random();
            bool isSame;
            for (int i = 0; i < 3; i++)   //5문제중 중복안되는 3문제의 index를 저장하는 알고리즘
            {
                while (true)
                {
                    array1[i] = r.Next(0, 5);   //우선 0~4중에 무작위로 하나를 저장 
                    isSame = false;   //isSame를 false 로 해두고
                    for (int j = 0; j < i; j++)  //이전에 이미 중복되는 값이 있나 확인 
                    {
                        if (array1[i] == array1[j])  //중복되는 값이 있으면 isSame를 true로 바꾸기
                        {
                            isSame = true;
                            break;
                        }
                    }
                    if (!isSame) break;  //isSame이 false이면 while문 빠져나감
                }
            }
            int[] array2 = new int[4];  //무작위로 보기 4가지의 index를 넣을 배열 하나 생성 
            bool isSame2;
            for (int i = 0; i < 4; i++) //보기 4가지를 중복안되도록 하여 index를 무작위로 저장하기 위한 알고리즘
            {
                while (true)
                {
                    array2[i] = r.Next(0, 4);  //0~3중에 random하게 하나의 값을 배열에 저장
                    isSame2 = false;  //isSame2를 false로 초기화
                    for (int j = 0; j < i; j++)  //이전에 이미 중복되는 값이 있나 확인
                    {
                        if (array2[i] == array2[j])  //만약 중복되는 값이 있으면 isSame2를 true로 바꾸기
                        {
                            isSame2 = true;
                            break;
                        }
                    }
                    if (!isSame2) break;  //만약 isSame이 false이면 while문을 빠져나옴
                }
            }
            for (int n = 0; n < 3; n++)  //총 3문제를 출력
            {
                GB[n] = new GroupBox();  //GroupBox의 객체를 생성
                this.GB[n].AutoSize = true;
                this.GB[n].Location = new System.Drawing.Point(10, 10 + (n * 150));  //GroupBox의 위치를 지정
                this.GB[n].Size = new System.Drawing.Size(350, 120);  //GroupBox의 크기를 지정
                this.GB[n].TabIndex = 0;
                this.GB[n].TabStop = false;
                this.GB[n].Text = aa + (n + 1) + "]" + Question[array1[n], 0];  // array1[n]번째에 해당하는 문제를 GroupBox의 Text에 저장 
                if (array1[n] == 4)  //만약 질문은 텍스트이고 보기는 그림이면
                {
                    P[4] = new PictureBox();    //PictureBox배열의 마지막 번째 객체를 하나 생성
                    P[4].SizeMode = PictureBoxSizeMode.StretchImage; //PictureBox에 꽉찬 이미지가 들어가도록 설정
                    P[4].ImageLocation="Images/골든리트리버.PNG";  //골든리트리버 사진 가져오기
                    this.P[4].Location = new System.Drawing.Point(20, 20);  //사진의 위치 지정
                    this.P[4].Size = new System.Drawing.Size(80, 80);  //사진의 크기 지정
                    this.GB[n].Controls.Add(this.P[4]);  //사진을 GroupBox에 추가하기
                }
                this.Controls.Add(GB[n]);  //GroupBbox를 윈도우 폼에 추가
                for (int i = 0; i < 4; i++)  //보기 4가지를 넣기 위한 알고리즘
                {
                    Bogi[n, i] = new RadioButton();  //RadionButton의 객체를 생성
                    if (array1[n] == 3)  //만약 보기가 사진이고 질문이 텍스트인 문제이면
                    {
                        P[i] = new PictureBox();  //PictureBox 객체 생성
                        P[i].SizeMode = PictureBoxSizeMode.StretchImage; //PictureBox에 꽉찬 이미지가 들어가도록 설정
                        this.P[i].Size = new System.Drawing.Size(60, 40);//사진의 크기 지정
                        if (i % 2 == 0)  //만약 보기가 0번째, 2번째이면
                        {
                            this.Bogi[n, i].Location = new System.Drawing.Point(20, 30 + (i * 30)); //보기의 위치를 왼쪽에 지정
                            if (i == 0)  //만약 0번째 보기이면
                                P[i].ImageLocation = "Images/아이유1.PNG";  //아이유 사진 추가
                            else  //만약 2번째 보기이면
                                P[i].ImageLocation = "Images/아이유2.jpg";  //아이유 사진 추가
                            this.P[i].Location = new System.Drawing.Point(Bogi[n, i].Location.X + 15, Bogi[n, i].Location.Y);//사진의 위치를 라디오 버튼의 x값보다 15 오른쪽에 위치하도록 설정
                        }
                        else //만약 보기가 1번째 3번째이면
                        {
                            this.Bogi[n, i].Location = new System.Drawing.Point(180, 30 + ((i - 1) * 30));  //보기의 위치를 오른쪽에 지정
                            if (i == 1)
                                P[i].ImageLocation = "Images/아이유3.PNG";  //아이유 사진 추가
                            else
                                P[i].ImageLocation = "Images/마동석.PNG";  //마동석 사진 추가

                            this.P[i].Location = new System.Drawing.Point(Bogi[n, i].Location.X + 15, Bogi[n, i].Location.Y); //사진의 위치를 라디오 버튼의 x값보다 15 오른쪽에 위치하도록 설정
                        }
                        this.GB[n].Controls.Add(this.P[i]);  //사진을 GroupBox에 추가
                        this.Bogi[n, i].Size = new System.Drawing.Size(100, 20);  //보기의 사이즈 지정
                        this.Bogi[n, i].Text = Question[array1[n], i + 1];    //보기를 순서대로 1번,2번,3번, 4번 으로 지정
                        this.Controls.Add(Bogi[n, i]);  //보기를 폼에 추가
                        this.GB[n].Controls.Add(this.Bogi[n, i]);  //보기를 GroupBox에 추가
                    }
                    else
                    {
                        if (array1[n] == 4)  //질문은 그림이고 보기는 텍스트인 문제이면
                            this.Bogi[n, i].Location = new System.Drawing.Point(110, 30 + (i * 20));  //보기의 위치를 사진보다 오른쪽에 지정
                        else //질문, 보기 모두 텍스트인 문제이면
                            this.Bogi[n, i].Location = new System.Drawing.Point(30, 30 + (i * 20));   //보기의 위치를 지정
                        this.Bogi[n, i].Size = new System.Drawing.Size(100, 20);  //보기의 사이즈 지정
                        this.Bogi[n, i].Text = Question[array1[n], array2[i] + 1];  //보기의 순서를 무작위로 지정
                        this.Controls.Add(Bogi[n, i]);  //보기를 폼에 추가
                        this.GB[n].Controls.Add(this.Bogi[n, i]);  //보기를 GroupBox에 추가
                    }
                }
            }
        
    }
        void button_Click(object sender, EventArgs e)  //버튼이 눌렸을때
        {
            Score = 0;   //Score를 0으로 초기화
            Button button = sender as Button;
            for (int i = 0; i < 3; i++)  //3문제에 대해서
            {
                for (int j = 0; j < 4; j++)  //4가지 보기에 대해서
                {
                    if (Bogi[i, j].Checked)   //만약 보기가 선택되었으면
                        if (Bogi[i, j].Text == "이" || Bogi[i, j].Text == "계양산" || Bogi[i, j].Text == "연수구" || Bogi[i, j].Text == "4" || Bogi[i, j].Text == "골든리트리버")  //선택된 보기가 정답이면
                            Score++;  //score를 1증가시킴
                }
            }
            lbScore.Text = "Score: " + Convert.ToString(Score) + "점";  //label에 점수 입력
        }
    }
}
