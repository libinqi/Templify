namespace Endjin.Templify.Domain.Tasks
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    using Endjin.Templify.Domain.Contracts.Infrastructure;
    using Endjin.Templify.Domain.Contracts.Packager.Notifiers;
    using Endjin.Templify.Domain.Contracts.Packager.Processors;
    using Endjin.Templify.Domain.Contracts.Packages;
    using Endjin.Templify.Domain.Contracts.Tasks;
    using Endjin.Templify.Domain.Domain.Packages;
    using Endjin.Templify.Domain.Infrastructure;

    #endregion

    [Export(typeof(IPackageDeployerTasks))]
    public class PackageDeployerTasks : IPackageDeployerTasks
    {
        #region Fields

        private readonly IConfiguration configuration;
        private readonly IProgressNotifier progressNotifier;
        private readonly IPackageDeploymentProcessor packageDeploymentProcessor;
        private readonly IPackageProcessor packageProcessor;
        private readonly IPackageRepository packageRepository;
        private CommandOptions commandOptions;

        #endregion

        [ImportingConstructor]
        public PackageDeployerTasks(
            IConfiguration configuration,
            IPackageDeploymentProcessor packageDeploymentProcessor,
            IPackageProcessor packageProcessor,
            IPackageRepository packageRepository, 
            IProgressNotifier progressNotifier)
        {
            this.packageDeploymentProcessor = packageDeploymentProcessor;
            this.configuration = configuration;
            this.packageProcessor = packageProcessor;
            this.packageRepository = packageRepository;
            this.progressNotifier = progressNotifier;
            this.progressNotifier.Progress += this.OnProgressUpdate;
        }
        
        public event EventHandler<PackageProgressEventArgs> Progress;

        #region Properties

        public int CurrentProgress { get; set; }

        public int MaxProgress { get; set; }

        public string ProgressStatus { get; set; }

        #endregion

        public void DeployPackage(CommandOptions options)
        {
            this.commandOptions = options;
            this.configuration.PackageRepositoryPath = options.PackageRepositoryPath;

            this.RunDeployPackage();
        }

        public IEnumerable<Package> RetrieveAllPackages()
        {
            return this.packageRepository.FindAll();
        }
        
        public IEnumerable<Package> RetrieveAllPackages(string repositoryPath)
        {
            this.configuration.PackageRepositoryPath = repositoryPath;
            return this.packageRepository.FindAll();
        }

        public IEnumerable<string> RetrieveTokensForPackage(string packageName, string repositoryPath)
        {
            this.configuration.PackageRepositoryPath = repositoryPath;
            var package = this.packageRepository.FindOne(packageName);

            return package.Manifest.Tokens;
        }

        private void RunDeployPackage()
        {
            var package = this.packageRepository.FindOne(this.commandOptions.PackageName);
            package.Manifest.InstallRoot = this.commandOptions.Path;
            
            this.packageDeploymentProcessor.Execute(package);
            this.packageProcessor.Process(this.commandOptions.Path, this.commandOptions.Tokens);
        }

        private void OnProgressUpdate(object sender, PackageProgressEventArgs e)
        {
            if (this.Progress != null)
            {
                this.Progress(sender, e);
            }
        }
    }
}