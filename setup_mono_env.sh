#!/bin/bash
set -e

echo "Starting Mono environment setup for EPPlus..."

# 1. Install system dependencies
echo "Installing Mono and Xvfb..."
sudo apt-get update
sudo apt-get install -y mono-complete xvfb curl

# 2. Setup NuGet
echo "Downloading NuGet..."
mkdir -p ~/.local/bin
curl -Lo ~/.local/bin/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe

# Create a helper script for nuget
cat <<EOF > ~/.local/bin/nuget
#!/bin/bash
mono ~/.local/bin/nuget.exe "\$@"
EOF
chmod +x ~/.local/bin/nuget

# Add ~/.local/bin to PATH for the current session if not already there
export PATH="\$HOME/.local/bin:\$PATH"

# 3. Setup Test Runners
echo "Setting up test runners..."
RUNNER_DIR="\$HOME/.local/share/dotnet-runners"
mkdir -p "\$RUNNER_DIR"

# Install MSTest Platform, AltCover, and ReportGenerator
echo "Setting up test and coverage runners..."
RUNNER_DIR="$HOME/.local/share/dotnet-runners"
mkdir -p "$RUNNER_DIR"

mono ~/.local/bin/nuget.exe install Microsoft.TestPlatform -Version 16.11.0 -OutputDirectory "$RUNNER_DIR/vstest-runner"
mono ~/.local/bin/nuget.exe install altcover -Version 8.6.14 -OutputDirectory "$RUNNER_DIR/altcover"
mono ~/.local/bin/nuget.exe install reportgenerator -Version 5.2.0 -OutputDirectory "$RUNNER_DIR/reportgenerator"


# 4. Restore Solution Packages
echo "Restoring NuGet packages for EPPlus..."
mono ~/.local/bin/nuget.exe restore EPPlus.sln

# 5. Build Solution
echo "Building EPPlus solution..."
xbuild /p:Configuration=Debug EPPlus.sln

echo "--------------------------------------------------"
echo "Setup Complete!"
echo "Runners are located in: \$RUNNER_DIR"
echo "You can now run tests using the commands in MONO_SETUP.md"
echo "--------------------------------------------------"
