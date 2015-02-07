namespace Endjin.Templify.Domain.Domain.Packages
{
    using System.ComponentModel;

    public enum ProgressStage
    {
        [Description("�������ļ��嵥")]
        BuildManifest,

        [Description("������")]
        BuildPackage,

        [Description("������ʱ�ļ�")]
        CleanUp,

        [Description("���ư�")]
        ClonePackage,

        [Description("���������д浵")]
        CreatingArchive,

        [Description("��ѹ���ļ�")]
        ExtractFilesFromPackage,

        [Description("������������")]
        TokenisePackageContents,

        [Description("�������Ľṹ")]
        TokenisePackageStructure,
    }
}