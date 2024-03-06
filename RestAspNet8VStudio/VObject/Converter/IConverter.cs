namespace RestAspNet8VStudio.VObject.Converter
{
    public interface IConverter <I,O>
    {
        O Convert(I input);
        List<O> Convert (List<I> input);
    }
}
