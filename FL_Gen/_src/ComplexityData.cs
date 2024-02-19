public class ComplexityData {

    public int MaxLvlNumber;
    public int Complexity;
    public int IdCount;
    public int flasksCount;
    public int SameIdProb1;
    public int SameIdProb2;
    public int freqOf5Flask1;
    public int freqOf5Flask2;

    public ComplexityData(int compl, int maxLvlNum, int idCount, int sameIDProb1, int sameIDProb2, int freq5_1, int freq5_2) {
        this.MaxLvlNumber = maxLvlNum;
        this.Complexity = compl;
        this.IdCount = idCount;
        SameIdProb1 = sameIDProb1;
        SameIdProb2 = sameIDProb2;
        this.freqOf5Flask1 = freq5_1;
        this.freqOf5Flask2 = freq5_2;
    }
}
    
        

    