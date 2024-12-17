//537. Complex Number Multiplication med
//题目：复数可以表示为字符串形式 "real+imaginaryi"，其中：
//real 表示复数的实部，是一个范围在[-100, 100] 之间的整数。
//imaginary 表示复数的虚部，也是一个范围在[-100, 100] 之间的整数。
//i^2=-1;
//给定两个表示复数的字符串 num1 和 num2，返回一个字符串，表示这两个复数相乘后的结果。
//思路：解析复数：从字符串 num1 和 num2 中提取实部 real 和虚部 imaginary。
//复数乘法规则：如果两个复数为 a+bi 和 c+di，则它们的乘积为：
//(a+bi)×(c+di)=(ac−bd)+(ad+bc)i
//其中：实部结果为 ac−bd;虚部结果为 ad+bc
//组装结果：将计算出的实部和虚部转换回字符串格式 "real+imaginaryi"。
//时间复杂度:  O(L)
//空间复杂度： O(1)
        public string ComplexNumberMultiply(string num1, string num2)
        {
            // 解析第一个复数
            var parts1 = ParseComplex(num1);
            int real1 = parts1.Item1, imaginary1 = parts1.Item2;

            // 解析第二个复数
            var parts2 = ParseComplex(num2);
            int real2 = parts2.Item1, imaginary2 = parts2.Item2;

            // 计算实部和虚部
            int realPart = real1 * real2 - imaginary1 * imaginary2;
            int imaginaryPart = real1 * imaginary2 + imaginary1 * real2;

            // 返回结果字符串
            return $"{realPart}+{imaginaryPart}i";
        }