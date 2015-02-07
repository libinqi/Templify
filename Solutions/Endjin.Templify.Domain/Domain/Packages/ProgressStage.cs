namespace Endjin.Templify.Domain.Domain.Packages
{
    using System.ComponentModel;

    public enum ProgressStage
    {
        [Description("构建包文件清单")]
        BuildManifest,

        [Description("构建包")]
        BuildPackage,

        [Description("清理临时文件")]
        CleanUp,

        [Description("复制包")]
        ClonePackage,

        [Description("创建包进行存档")]
        CreatingArchive,

        [Description("解压包文件")]
        ExtractFilesFromPackage,

        [Description("构建包的内容")]
        TokenisePackageContents,

        [Description("构建包的结构")]
        TokenisePackageStructure,
    }
}