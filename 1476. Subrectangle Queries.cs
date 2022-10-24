1476. Subrectangle Queries
//C#
public class SubrectangleQueries {

    int[][] rectangleOutput;
    public SubrectangleQueries(int[][] rectangle) {
        rectangleOutput = rectangle;
    }
    
    public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue) {
        for (int i = row1; i <= row2; i++)
            for (int j = col1; j <= col2; j++)
                    rectangleOutput[i][j] = newValue;
    }
    
    public int GetValue(int row, int col) {
        return rectangleOutput[row][col];
    }
}

/**
 * Your SubrectangleQueries object will be instantiated and called as such:
 * SubrectangleQueries obj = new SubrectangleQueries(rectangle);
 * obj.UpdateSubrectangle(row1,col1,row2,col2,newValue);
 * int param_2 = obj.GetValue(row,col);
 */