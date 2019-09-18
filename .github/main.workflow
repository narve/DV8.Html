workflow "New workflow" {
  on = "push"
  resolves = ["Setup Dotnet for use with actions"]
}

action "Setup Dotnet for use with actions" {
  uses = "actions/setup-dotnet@6c0e2a2a6b8dbd557c411f0bd105b341d4ce40d2"
}
