namespace AffinTransform3D
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.icosahedron = new System.Windows.Forms.RadioButton();
            this.dodecahedron = new System.Windows.Forms.RadioButton();
            this.octahedron = new System.Windows.Forms.RadioButton();
            this.hexahedron = new System.Windows.Forms.RadioButton();
            this.tetrahedron = new System.Windows.Forms.RadioButton();
            this.displacement_button = new System.Windows.Forms.Button();
            this.z_shift = new System.Windows.Forms.NumericUpDown();
            this.y_shift = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.x_shift = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rotate_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.z_rotate = new System.Windows.Forms.NumericUpDown();
            this.y_rotate = new System.Windows.Forms.NumericUpDown();
            this.x_rotate = new System.Windows.Forms.NumericUpDown();
            this.z_scale = new System.Windows.Forms.NumericUpDown();
            this.scale_button = new System.Windows.Forms.Button();
            this.y_scale = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.x_scale = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.yoz_reflect = new System.Windows.Forms.CheckBox();
            this.xoz_reflect = new System.Windows.Forms.CheckBox();
            this.xoy_reflect = new System.Windows.Forms.CheckBox();
            this.reflect_button = new System.Windows.Forms.Button();
            this.axis_angle = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.axis_choice_button = new System.Windows.Forms.Button();
            this.axis_rotate_button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.z2_coord = new System.Windows.Forms.NumericUpDown();
            this.z1_coord = new System.Windows.Forms.NumericUpDown();
            this.axis_del_button = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_shift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_shift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_shift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_rotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_rotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_rotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axis_angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z2_coord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z1_coord)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(940, 637);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // icosahedron
            // 
            this.icosahedron.AutoSize = true;
            this.icosahedron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.icosahedron.Location = new System.Drawing.Point(961, 112);
            this.icosahedron.Name = "icosahedron";
            this.icosahedron.Size = new System.Drawing.Size(75, 17);
            this.icosahedron.TabIndex = 4;
            this.icosahedron.TabStop = true;
            this.icosahedron.Text = "Икосаэдр";
            this.icosahedron.UseVisualStyleBackColor = true;
            this.icosahedron.CheckedChanged += new System.EventHandler(this.shape_CheckedChanged);
            // 
            // dodecahedron
            // 
            this.dodecahedron.AutoSize = true;
            this.dodecahedron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dodecahedron.Location = new System.Drawing.Point(961, 87);
            this.dodecahedron.Name = "dodecahedron";
            this.dodecahedron.Size = new System.Drawing.Size(82, 17);
            this.dodecahedron.TabIndex = 3;
            this.dodecahedron.TabStop = true;
            this.dodecahedron.Text = "Додекаэдр";
            this.dodecahedron.UseVisualStyleBackColor = true;
            this.dodecahedron.CheckedChanged += new System.EventHandler(this.shape_CheckedChanged);
            // 
            // octahedron
            // 
            this.octahedron.AutoSize = true;
            this.octahedron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.octahedron.Location = new System.Drawing.Point(961, 62);
            this.octahedron.Name = "octahedron";
            this.octahedron.Size = new System.Drawing.Size(68, 17);
            this.octahedron.TabIndex = 2;
            this.octahedron.TabStop = true;
            this.octahedron.Text = "Октаэдр";
            this.octahedron.UseVisualStyleBackColor = true;
            this.octahedron.CheckedChanged += new System.EventHandler(this.shape_CheckedChanged);
            // 
            // hexahedron
            // 
            this.hexahedron.AutoSize = true;
            this.hexahedron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hexahedron.Location = new System.Drawing.Point(961, 37);
            this.hexahedron.Name = "hexahedron";
            this.hexahedron.Size = new System.Drawing.Size(73, 17);
            this.hexahedron.TabIndex = 1;
            this.hexahedron.TabStop = true;
            this.hexahedron.Text = "Гексаэдр";
            this.hexahedron.UseVisualStyleBackColor = true;
            this.hexahedron.CheckedChanged += new System.EventHandler(this.shape_CheckedChanged);
            // 
            // tetrahedron
            // 
            this.tetrahedron.AutoSize = true;
            this.tetrahedron.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tetrahedron.Location = new System.Drawing.Point(961, 12);
            this.tetrahedron.Name = "tetrahedron";
            this.tetrahedron.Size = new System.Drawing.Size(73, 17);
            this.tetrahedron.TabIndex = 0;
            this.tetrahedron.TabStop = true;
            this.tetrahedron.Text = "Тетраэдр";
            this.tetrahedron.UseVisualStyleBackColor = true;
            this.tetrahedron.CheckedChanged += new System.EventHandler(this.shape_CheckedChanged);
            // 
            // displacement_button
            // 
            this.displacement_button.Location = new System.Drawing.Point(1073, 112);
            this.displacement_button.Name = "displacement_button";
            this.displacement_button.Size = new System.Drawing.Size(84, 25);
            this.displacement_button.TabIndex = 6;
            this.displacement_button.Text = "ОК";
            this.displacement_button.UseVisualStyleBackColor = true;
            this.displacement_button.Click += new System.EventHandler(this.displacement_button_Click);
            // 
            // z_shift
            // 
            this.z_shift.Location = new System.Drawing.Point(1093, 85);
            this.z_shift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.z_shift.Name = "z_shift";
            this.z_shift.Size = new System.Drawing.Size(64, 20);
            this.z_shift.TabIndex = 5;
            // 
            // y_shift
            // 
            this.y_shift.Location = new System.Drawing.Point(1093, 59);
            this.y_shift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.y_shift.Name = "y_shift";
            this.y_shift.Size = new System.Drawing.Size(64, 20);
            this.y_shift.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1071, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // x_shift
            // 
            this.x_shift.Location = new System.Drawing.Point(1093, 35);
            this.x_shift.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.x_shift.Name = "x_shift";
            this.x_shift.Size = new System.Drawing.Size(64, 20);
            this.x_shift.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1070, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1070, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Z:";
            // 
            // rotate_button
            // 
            this.rotate_button.Location = new System.Drawing.Point(961, 414);
            this.rotate_button.Name = "rotate_button";
            this.rotate_button.Size = new System.Drawing.Size(90, 27);
            this.rotate_button.TabIndex = 10;
            this.rotate_button.Text = "ОК";
            this.rotate_button.UseVisualStyleBackColor = true;
            this.rotate_button.Click += new System.EventHandler(this.rotate_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(958, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "0Z:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(958, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "0Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(958, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "0X:";
            // 
            // z_rotate
            // 
            this.z_rotate.Location = new System.Drawing.Point(987, 388);
            this.z_rotate.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.z_rotate.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.z_rotate.Name = "z_rotate";
            this.z_rotate.Size = new System.Drawing.Size(64, 20);
            this.z_rotate.TabIndex = 6;
            // 
            // y_rotate
            // 
            this.y_rotate.Location = new System.Drawing.Point(987, 362);
            this.y_rotate.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.y_rotate.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.y_rotate.Name = "y_rotate";
            this.y_rotate.Size = new System.Drawing.Size(64, 20);
            this.y_rotate.TabIndex = 5;
            // 
            // x_rotate
            // 
            this.x_rotate.Location = new System.Drawing.Point(987, 336);
            this.x_rotate.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.x_rotate.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.x_rotate.Name = "x_rotate";
            this.x_rotate.Size = new System.Drawing.Size(64, 20);
            this.x_rotate.TabIndex = 4;
            // 
            // z_scale
            // 
            this.z_scale.DecimalPlaces = 1;
            this.z_scale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.z_scale.Location = new System.Drawing.Point(979, 237);
            this.z_scale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.z_scale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.z_scale.Name = "z_scale";
            this.z_scale.Size = new System.Drawing.Size(64, 20);
            this.z_scale.TabIndex = 6;
            this.z_scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // scale_button
            // 
            this.scale_button.Location = new System.Drawing.Point(961, 263);
            this.scale_button.Name = "scale_button";
            this.scale_button.Size = new System.Drawing.Size(82, 27);
            this.scale_button.TabIndex = 6;
            this.scale_button.Text = "ОК";
            this.scale_button.UseVisualStyleBackColor = true;
            this.scale_button.Click += new System.EventHandler(this.scale_button_Click);
            // 
            // y_scale
            // 
            this.y_scale.DecimalPlaces = 1;
            this.y_scale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.y_scale.Location = new System.Drawing.Point(979, 211);
            this.y_scale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.y_scale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.y_scale.Name = "y_scale";
            this.y_scale.Size = new System.Drawing.Size(64, 20);
            this.y_scale.TabIndex = 5;
            this.y_scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(958, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Y:";
            // 
            // x_scale
            // 
            this.x_scale.DecimalPlaces = 1;
            this.x_scale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.x_scale.Location = new System.Drawing.Point(979, 185);
            this.x_scale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.x_scale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.x_scale.Name = "x_scale";
            this.x_scale.Size = new System.Drawing.Size(64, 20);
            this.x_scale.TabIndex = 3;
            this.x_scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(958, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "X:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(958, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Z:";
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_button.Location = new System.Drawing.Point(1074, 622);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(90, 27);
            this.cancel_button.TabIndex = 5;
            this.cancel_button.Text = "Сброс";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // yoz_reflect
            // 
            this.yoz_reflect.AutoSize = true;
            this.yoz_reflect.Location = new System.Drawing.Point(1073, 235);
            this.yoz_reflect.Name = "yoz_reflect";
            this.yoz_reflect.Size = new System.Drawing.Size(48, 17);
            this.yoz_reflect.TabIndex = 13;
            this.yoz_reflect.Text = "YOZ";
            this.yoz_reflect.UseVisualStyleBackColor = true;
            // 
            // xoz_reflect
            // 
            this.xoz_reflect.AutoSize = true;
            this.xoz_reflect.Location = new System.Drawing.Point(1073, 209);
            this.xoz_reflect.Name = "xoz_reflect";
            this.xoz_reflect.Size = new System.Drawing.Size(48, 17);
            this.xoz_reflect.TabIndex = 12;
            this.xoz_reflect.Text = "XOZ";
            this.xoz_reflect.UseVisualStyleBackColor = true;
            // 
            // xoy_reflect
            // 
            this.xoy_reflect.AutoSize = true;
            this.xoy_reflect.Location = new System.Drawing.Point(1073, 186);
            this.xoy_reflect.Name = "xoy_reflect";
            this.xoy_reflect.Size = new System.Drawing.Size(48, 17);
            this.xoy_reflect.TabIndex = 11;
            this.xoy_reflect.Text = "XOY";
            this.xoy_reflect.UseVisualStyleBackColor = true;
            // 
            // reflect_button
            // 
            this.reflect_button.Location = new System.Drawing.Point(1073, 263);
            this.reflect_button.Name = "reflect_button";
            this.reflect_button.Size = new System.Drawing.Size(84, 27);
            this.reflect_button.TabIndex = 10;
            this.reflect_button.Text = "ОК";
            this.reflect_button.UseVisualStyleBackColor = true;
            this.reflect_button.Click += new System.EventHandler(this.reflect_button_Click);
            // 
            // axis_angle
            // 
            this.axis_angle.Location = new System.Drawing.Point(1100, 388);
            this.axis_angle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.axis_angle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.axis_angle.Name = "axis_angle";
            this.axis_angle.Size = new System.Drawing.Size(64, 20);
            this.axis_angle.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(1071, 390);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "φ:";
            // 
            // axis_choice_button
            // 
            this.axis_choice_button.Location = new System.Drawing.Point(1073, 414);
            this.axis_choice_button.Name = "axis_choice_button";
            this.axis_choice_button.Size = new System.Drawing.Size(84, 27);
            this.axis_choice_button.TabIndex = 11;
            this.axis_choice_button.Text = "Выбрать ось";
            this.axis_choice_button.UseVisualStyleBackColor = true;
            this.axis_choice_button.Click += new System.EventHandler(this.axis_choice_button_Click);
            // 
            // axis_rotate_button
            // 
            this.axis_rotate_button.Location = new System.Drawing.Point(1073, 480);
            this.axis_rotate_button.Name = "axis_rotate_button";
            this.axis_rotate_button.Size = new System.Drawing.Size(84, 27);
            this.axis_rotate_button.TabIndex = 10;
            this.axis_rotate_button.Text = "ОК";
            this.axis_rotate_button.UseVisualStyleBackColor = true;
            this.axis_rotate_button.Click += new System.EventHandler(this.axis_rotate_button_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(1071, 364);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Z2:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(1071, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Z1:";
            // 
            // z2_coord
            // 
            this.z2_coord.Location = new System.Drawing.Point(1100, 362);
            this.z2_coord.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.z2_coord.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.z2_coord.Name = "z2_coord";
            this.z2_coord.Size = new System.Drawing.Size(64, 20);
            this.z2_coord.TabIndex = 6;
            // 
            // z1_coord
            // 
            this.z1_coord.Location = new System.Drawing.Point(1100, 336);
            this.z1_coord.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.z1_coord.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.z1_coord.Name = "z1_coord";
            this.z1_coord.Size = new System.Drawing.Size(64, 20);
            this.z1_coord.TabIndex = 5;
            // 
            // axis_del_button
            // 
            this.axis_del_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.axis_del_button.Location = new System.Drawing.Point(1073, 447);
            this.axis_del_button.Name = "axis_del_button";
            this.axis_del_button.Size = new System.Drawing.Size(84, 27);
            this.axis_del_button.TabIndex = 8;
            this.axis_del_button.Text = "Удалить ось";
            this.axis_del_button.UseVisualStyleBackColor = true;
            this.axis_del_button.Click += new System.EventHandler(this.axis_del_button_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(958, 312);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Поворот:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(958, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Масштабирование:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1070, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Перенос:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1070, 164);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Отражение:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1070, 312);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Поворот вокруг оси:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(963, 596);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(174, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Не перерисовывать текущее";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.axis_angle);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.yoz_reflect);
            this.Controls.Add(this.axis_choice_button);
            this.Controls.Add(this.axis_rotate_button);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.xoz_reflect);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.displacement_button);
            this.Controls.Add(this.z2_coord);
            this.Controls.Add(this.xoy_reflect);
            this.Controls.Add(this.z1_coord);
            this.Controls.Add(this.reflect_button);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.z_shift);
            this.Controls.Add(this.z_scale);
            this.Controls.Add(this.y_shift);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scale_button);
            this.Controls.Add(this.x_shift);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rotate_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.y_scale);
            this.Controls.Add(this.icosahedron);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.x_scale);
            this.Controls.Add(this.axis_del_button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dodecahedron);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.z_rotate);
            this.Controls.Add(this.y_rotate);
            this.Controls.Add(this.octahedron);
            this.Controls.Add(this.x_rotate);
            this.Controls.Add(this.hexahedron);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.tetrahedron);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "3D векторная графика";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_shift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_shift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_shift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_rotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_rotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_rotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axis_angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z2_coord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z1_coord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RadioButton tetrahedron;
        private System.Windows.Forms.RadioButton hexahedron;
        private System.Windows.Forms.RadioButton octahedron;
        private System.Windows.Forms.RadioButton dodecahedron;
        private System.Windows.Forms.RadioButton icosahedron;
        private System.Windows.Forms.Button displacement_button;
        private System.Windows.Forms.NumericUpDown z_shift;
        private System.Windows.Forms.NumericUpDown y_shift;
        private System.Windows.Forms.NumericUpDown x_shift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rotate_button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown z_rotate;
        private System.Windows.Forms.NumericUpDown y_rotate;
        private System.Windows.Forms.NumericUpDown x_rotate;
        private System.Windows.Forms.Button scale_button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown x_scale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown z_scale;
        private System.Windows.Forms.NumericUpDown y_scale;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button reflect_button;
        private System.Windows.Forms.CheckBox yoz_reflect;
        private System.Windows.Forms.CheckBox xoz_reflect;
        private System.Windows.Forms.CheckBox xoy_reflect;
        private System.Windows.Forms.Button axis_rotate_button;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown z2_coord;
        private System.Windows.Forms.NumericUpDown z1_coord;
        private System.Windows.Forms.Button axis_choice_button;
        private System.Windows.Forms.Button axis_del_button;
        private System.Windows.Forms.NumericUpDown axis_angle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

