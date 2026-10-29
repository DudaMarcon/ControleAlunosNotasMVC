FROM ://microsoft.com AS compilador
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM ://microsoft.com
WORKDIR /app
COPY --from=compilador /app .
EXPOSE 8080
ENTRYPOINT ["dotnet", "ControleAlunosNotasMVC.dll"]
